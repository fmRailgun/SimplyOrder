using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimplyOrder {
    public partial class MainWindow : Window {

        private void InitCustom(Food f, int i) {

            int height = f.OptionCount * 20 + 50;

            Grid cg = new Grid();
            cg.DataContext = f;
            cg.Width = Double.NaN;
            cg.Height = height;
            cg.Margin = new Thickness(15, 0, 15, 10);
            cg.Visibility = Visibility.Collapsed;
            this.RegisterName(f.Name + "cg", cg);


            Border b = new Border();
            b.BorderBrush = System.Windows.Media.Brushes.Black;
            b.BorderThickness = new Thickness(2);
            cg.Children.Add(b);

            Grid g = new Grid();
            RowDefinition cr1 = new RowDefinition();
            cr1.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition cr2 = new RowDefinition();
            cr2.Height = new GridLength(4, GridUnitType.Star);
            g.RowDefinitions.Add(cr1);
            g.RowDefinitions.Add(cr2);

            ColumnDefinition cc1 = new ColumnDefinition();
            cc1.Width = new GridLength(3, GridUnitType.Star);
            ColumnDefinition cc2 = new ColumnDefinition();
            cc2.Width = new GridLength(1, GridUnitType.Star);
            g.ColumnDefinitions.Add(cc1);
            g.ColumnDefinitions.Add(cc2);

            g.Children.Add(InitDesc(f));
            g.Children.Add(InitCustomPrice(f));
            g.Children.Add(InitCustomOptions(f));
            cg.Children.Add(g);

            Menu.Children.Add(cg);
        }

        //Init description
        private Label InitDesc(Food f) {
            Label desc = new Label();
            desc.Padding = new Thickness(10, 10, 10, 10);
            desc.SetValue(Grid.RowProperty, 0);
            desc.SetValue(Grid.ColumnSpanProperty, 2);
            desc.Content = f.Desciption;
            return desc;
        }

        //Init price
        private Grid InitCustomPrice(Food f) {

            Grid p = new Grid();
            p.SetValue(Grid.RowProperty, 1);
            p.SetValue(Grid.ColumnProperty, 1);

            Label price = new Label();
            price.Margin = new Thickness(10, 10, 10, 100);
            price.Content = f.Price;
            price.VerticalAlignment = VerticalAlignment.Bottom;
            p.Children.Add(price);
            this.RegisterName(f.Name + "price", price);
            price.Name = f.Name + "price";

            Button add = new Button();
            add.AddHandler(Button.ClickEvent, new RoutedEventHandler(AddClicked));
            add.Margin = new Thickness(10, 10, 10, 10);
            add.VerticalAlignment = VerticalAlignment.Bottom;
            add.Content = "Add to Order";
            add.DataContext = f;
            add.Width = 80;
            add.Height = 30;

            p.Children.Add(add);

            return p;
        }

        //Init price
        private ScrollViewer InitCustomOptions(Food f) {

            ScrollViewer sc = new ScrollViewer();
            sc.Margin = new Thickness(10, 10, 10, 10);
            sc.SetValue(Grid.RowProperty, 1);
            sc.SetValue(Grid.ColumnProperty, 0);
            sc.VerticalAlignment = VerticalAlignment.Bottom;
            sc.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;

            Grid scg = new Grid();
            sc.Content = scg;
            sc.Height = 150;

            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(1, GridUnitType.Star);
            scg.ColumnDefinitions.Add(c1);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(1, GridUnitType.Star);
            scg.ColumnDefinitions.Add(c2);

            StackPanel sp1 = new StackPanel();
            sp1.SetValue(Grid.ColumnProperty, 0);
            scg.Children.Add(sp1);
            StackPanel sp2 = new StackPanel();
            sp2.SetValue(Grid.ColumnProperty, 1);
            scg.Children.Add(sp2);

            for (int i = 0; i < f.RequiredCustom.Length + f.OptionalCustom.Length; i+=2) {
                if (i == f.RequiredCustom.Length + f.OptionalCustom.Length - 1) {
                    if(i >= f.RequiredCustom.Length) {
                        Grid g = InitOptCustomHelper(f, f.OptionalCustom[i- f.RequiredCustom.Length], f.OptionalCustom[i - f.RequiredCustom.Length].Options.Length, i / 2 + 1);
                        sp1.Children.Add(g);
                    } else {
                        Grid g = InitReqCustomHelper(f, f.RequiredCustom[i], f.RequiredCustom[i].Options.Length, i / 2 + 1, f.Name+" "+i);
                        sp1.Children.Add(g);
                    }
                } else {
                    int row = 0;
                    if (f.RequiredCustom.Length == 0 || i >= f.RequiredCustom.Length) {
                        OptCustom left = f.OptionalCustom[i - f.RequiredCustom.Length];
                        OptCustom right = f.OptionalCustom[i + 1 - f.RequiredCustom.Length];
                        int nRow = left.Options.Length > right.Options.Length ? left.Options.Length : right.Options.Length;

                        Grid g1 = InitOptCustomHelper(f, left, nRow, row);
                        sp1.Children.Add(g1);

                        Grid g2 = InitOptCustomHelper(f, right, nRow, row);
                        sp2.Children.Add(g2);
                    } else if (f.OptionalCustom.Length == 0 || i < f.RequiredCustom.Length - 1) {
                        ReqCustom left = f.RequiredCustom[i];
                        ReqCustom right = f.RequiredCustom[i + 1];
                        int nRow = left.Options.Length > right.Options.Length ? left.Options.Length : right.Options.Length;

                        Grid g1 = InitReqCustomHelper(f, left, nRow, row, f.Name + " " + i);
                        sp1.Children.Add(g1);

                        Grid g2 = InitReqCustomHelper(f, right, nRow, row, f.Name + " " + i);
                        sp2.Children.Add(g2);
                    } else {
                        ReqCustom left = f.RequiredCustom[i];
                        OptCustom right = f.OptionalCustom[i+1 - f.RequiredCustom.Length];
                        int nRow = left.Options.Length > right.Options.Length ? left.Options.Length : right.Options.Length;

                        Grid g1 = InitReqCustomHelper(f, left, nRow, row, f.Name + " " + i);
                        sp1.Children.Add(g1);

                        Grid g2 = InitOptCustomHelper(f, right, nRow, row);
                        sp2.Children.Add(g2);
                    }
                    row += 2;
                }
            

            }

            return sc;
        }

        private Grid InitReqCustomHelper(Food f, ReqCustom options, int nRow, int rowNumber, string groupName) {
            Grid cus = new Grid();
            cus.Width = double.NaN;
            cus.Height = options.Options.Length * 20;
            cus.Margin = new Thickness(10, 10, 10, 10);
            cus.SetValue(Grid.RowProperty, rowNumber);
            cus.DataContext = options;
            cus.DataContext = f;

            int counter = 0;
            foreach (Option option in options.Options) {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(1, GridUnitType.Star);
                cus.RowDefinitions.Add(r);
                RadioButton b = new RadioButton();
                b.AddHandler(RadioButton.ClickEvent, new RoutedEventHandler(RadioButtonClicked));
                if (counter == 0) {
                    b.IsChecked = true;
                }
                b.SetValue(Grid.RowProperty, counter);
                b.GroupName = groupName;
                b.DataContext = options;
                b.Content = option.Name;
                cus.Children.Add(b);
                counter += 1;
            }
            while (counter < rowNumber) {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(1, GridUnitType.Star);
                cus.RowDefinitions.Add(r);
            }
            return cus;
        }


        private Grid InitOptCustomHelper(Food f, OptCustom options, int nRow, int rowNumber) {
            Grid cus = new Grid();
            cus.Width = double.NaN;
            cus.Height = options.Options.Length * 20;
            cus.Margin = new Thickness(10, 10, 10, 10);
            cus.DataContext = f;
            cus.SetValue(Grid.RowProperty, rowNumber);

            int counter = 0;
            foreach (Option option in options.Options) {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(1, GridUnitType.Star);
                cus.RowDefinitions.Add(r);
                CheckBox b = new CheckBox();
                b.DataContext = options;
                b.AddHandler(CheckBox.ClickEvent, new RoutedEventHandler(CheckBoxClicked));
                b.SetValue(Grid.RowProperty, counter);
                b.Content = option.Name;
                cus.Children.Add(b);
                counter += 1;
            }
            while (counter < rowNumber) {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(1, GridUnitType.Star);
                cus.RowDefinitions.Add(r);
            }
            return cus;
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e) {

            RadioButton rd = sender as RadioButton;
            
            ((ReqCustom)rd.DataContext).Select((string)rd.Content);

            Grid cus = rd.Parent as Grid;
            ((Food)cus.DataContext).CalculatePrice();

            double price = ((Food)cus.DataContext).Price;

            Label p = FindName(((Food)cus.DataContext).Name + "price") as Label;
            p.Content = price;
        }

        private void CheckBoxClicked(object sender, RoutedEventArgs e) {

            CheckBox cb = sender as CheckBox;

            ((OptCustom)cb.DataContext).Select((string)cb.Content);
            Grid cus = cb.Parent as Grid;
            ((Food)cus.DataContext).CalculatePrice();
            double price = ((Food)cus.DataContext).Price;

            Label p = FindName(((Food)cus.DataContext).Name + "price") as Label;
            p.Content = price;
        }

        private void AddClicked(object sender, RoutedEventArgs e) {
            Button add = sender as Button;

            OrderItem order = new OrderItem(Food.Clone((Food)add.DataContext));
            Food f = (Food)add.DataContext;
            MessageBox.Show(order.Name);
            foreach (OrderItem existingOrder in orderList) {
                if (existingOrder.Name == order.Name) {
                    Button plus = FindName(order.Name + "plus") as Button;
                    plus.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    return;
                }
            }
            InitOrder(order);
        }
       

    }
}
