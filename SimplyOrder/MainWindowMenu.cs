using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimplyOrder {
    public partial class MainWindow : Window {

        //Initialize menu
        private void InitMenu(Category category) {
            for (int i = 0; i < foods[(int)category].Length; i++) {

                InitFood(foods[(int)category][i], i);
                InitCustom(foods[(int)category][i], i);
            }
        }

        //Init a food in menu
        private void InitFood(Food f, int i) {
            Grid mg = new Grid();
            mg.DataContext = f;
            mg.Width = double.NaN;
            mg.Height = 150;
            mg.Margin = new Thickness(10, 10, 10, 10);

            Border b = new Border();
            b.BorderBrush = System.Windows.Media.Brushes.Black;
            b.BorderThickness = new Thickness(2);
            mg.Children.Add(b);

            Grid g = new Grid();
            ColumnDefinition c1 = new ColumnDefinition();
            c1.Width = new GridLength(5, GridUnitType.Star);
            ColumnDefinition c2 = new ColumnDefinition();
            c2.Width = new GridLength(10, GridUnitType.Star);
            ColumnDefinition c3 = new ColumnDefinition();
            c3.Width = new GridLength(5, GridUnitType.Star);
            ColumnDefinition c4 = new ColumnDefinition();
            c4.Width = new GridLength(2, GridUnitType.Star);
            g.ColumnDefinitions.Add(c1);
            g.ColumnDefinitions.Add(c2);
            g.ColumnDefinitions.Add(c3);
            g.ColumnDefinitions.Add(c4);


            g.Children.Add(InitFoodImg());
            g.Children.Add(InitFoodName(f));
            g.Children.Add(InitFoodPrice(f));

            //
            Label icon = new Label();
            this.RegisterName(f.Name + "Icon", icon);
            icon.Padding = new Thickness(10, 10, 10, 10);
            icon.SetValue(Grid.ColumnProperty, 3);
            icon.Content = "Up";
            g.Children.Add(icon);

            Button btn = new Button();
            btn.AddHandler(Button.ClickEvent, new RoutedEventHandler(MenuClicked));
            btn.Background = Brushes.Transparent;

            mg.Children.Add(g);
            mg.Children.Add(btn);
            Menu.Children.Add(mg);
        }

        private Image InitFoodImg() {
            Image img = new Image();
            img.Margin = new Thickness(10, 10, 10, 10);
            img.SetValue(Grid.ColumnProperty, 0);
            return img;
        }

        private Label InitFoodName(Food f) {
            Label name = new Label();
            name.Padding = new Thickness(10, 10, 10, 10);
            name.SetValue(Grid.ColumnProperty, 1);
            name.Content = f.Name;
            return name;
        }

        private Label InitFoodPrice(Food f) {
            Label price = new Label();
            price.Padding = new Thickness(10, 10, 10, 10);
            price.SetValue(Grid.ColumnProperty, 2);
            price.Content = f.Price;
            return price;
        }

        //Event handler
        static Grid dropdown = null;
        private void MenuClicked(object sender, RoutedEventArgs e) {
            Button mg = sender as Button;
            Label icon = FindName(((Food)mg.DataContext).Name + "Icon") as Label;
            if ((string)icon.Content == "Up") {
                icon.Content = "Down";
            } else {
                icon.Content = "Up";
            }

            Grid cg = FindName(((Food)mg.DataContext).Name + "cg") as Grid;
            if (cg.Visibility == Visibility.Visible) {
                cg.Visibility = Visibility.Collapsed;
            } else if (cg.Visibility == Visibility.Collapsed) {
                cg.Visibility = Visibility.Visible;
            }
            if (dropdown != null && dropdown != cg) {
                dropdown.Visibility = Visibility.Collapsed;
            }
            dropdown = cg;



            Grid p = FindName("Pivot") as Grid;
            ScrollViewer sv = FindName("MenuSV") as ScrollViewer;
            Point pos = mg.TransformToAncestor(p).Transform(new Point(0, 0));
            sv.ScrollToVerticalOffset(pos.Y - 10);
        }

       

    }
}
