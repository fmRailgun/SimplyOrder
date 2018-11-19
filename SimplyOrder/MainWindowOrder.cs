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

        List<OrderItem> orderList = new List<OrderItem>(0);

        private void InitOrder(OrderItem order) {

            orderList.Add(order);

            Food f = order.Food;
            Grid og = new Grid();
            RegisterName(order.Name + "og", og);
            og.Margin = new Thickness(10, 10, 10, 10);

            Grid g = new Grid();

            Border b = new Border();
            b.BorderBrush = System.Windows.Media.Brushes.Black;
            b.BorderThickness = new Thickness(2);
            og.Children.Add(b);

            RowDefinition cr1 = new RowDefinition();
            cr1.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition cr2 = new RowDefinition();
            cr2.Height = new GridLength(2, GridUnitType.Star);
            g.RowDefinitions.Add(cr1);
            g.RowDefinitions.Add(cr2);

            ColumnDefinition cc1 = new ColumnDefinition();
            cc1.Width = new GridLength(3, GridUnitType.Star);
            ColumnDefinition cc2 = new ColumnDefinition();
            cc2.Width = new GridLength(1, GridUnitType.Star);
            g.ColumnDefinitions.Add(cc1);
            g.ColumnDefinitions.Add(cc2);
            
            g.Children.Add(InitOrderPrice(order));
            g.Children.Add(InitOrderName(order));
            g.Children.Add(InitOrderDuplication(order));

            og.Children.Add(g);
            Order.Children.Add(og);

        }

        private Label InitOrderPrice(OrderItem order) {
            Label price = new Label();
            price.SetValue(Grid.ColumnProperty, 1);
            price.SetValue(Grid.RowSpanProperty, 2);
            price.DataContext = order;
            this.RegisterName(order.Name + "price", price);
            price.Content = order.Price;
            return price;
        }

        private Label InitOrderName(OrderItem order) {
            Label name = new Label();
            name.SetValue(Grid.ColumnProperty, 0);
            name.SetValue(Grid.RowProperty, 0);
            name.Content = order.Food.Name;
            return name;
        }

        private Grid InitOrderDuplication(OrderItem order) {
            Grid dup = new Grid();
            dup.SetValue(Grid.RowProperty, 1);
            dup.SetValue(Grid.ColumnProperty, 0);
            dup.DataContext = order;

            ColumnDefinition cc1 = new ColumnDefinition();
            cc1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition cc2 = new ColumnDefinition();
            cc2.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition cc3 = new ColumnDefinition();
            cc3.Width = new GridLength(1, GridUnitType.Star);
            dup.ColumnDefinitions.Add(cc1);
            dup.ColumnDefinitions.Add(cc2);
            dup.ColumnDefinitions.Add(cc3);

            Button plus = new Button();
            plus.SetValue(Grid.ColumnProperty, 0);
            plus.Content = "+";
            RegisterName(order.Name + "plus", plus);
            plus.DataContext = order;
            plus.AddHandler(Button.ClickEvent, new RoutedEventHandler(PlusClicked));
            dup.Children.Add(plus);

            Button minus = new Button();
            minus.SetValue(Grid.ColumnProperty, 2);
            minus.Content = "-";
            minus.DataContext = order;
            minus.AddHandler(Button.ClickEvent, new RoutedEventHandler(MinusClicked));
            dup.Children.Add(minus);

            Label counter = new Label();
            counter.SetValue(Grid.ColumnProperty, 1);
            counter.Content = "1";
            this.RegisterName(order.Name + "counter", counter);
            counter.DataContext = order;
            dup.Children.Add(counter);
            

            return dup;
        }


        private void PlusClicked(object sender, RoutedEventArgs e) {
            Button plus = sender as Button;
            OrderItem order = plus.DataContext as OrderItem;
            
            order.Count++;

            Label counter = FindName(order.Name+"counter") as Label;
            counter.Content = order.Count;

            Label price = FindName(order.Name + "price") as Label;
            price.Content = order.CalculatePrice();
        }

        private void MinusClicked(object sender, RoutedEventArgs e) {
            Button minus = sender as Button;

            OrderItem order = minus.DataContext as OrderItem;

            order.Count--;
            if (order.Count == 0) {
                orderList.Remove(order);
                Grid og = FindName(order.Name + "og") as Grid;
                Order.Children.Remove(og);
                UnregisterName(order.Name+ "og");
                UnregisterName(order.Name+ "price");
                UnregisterName(order.Name + "counter");
                UnregisterName(order.Name + "plus");
                return;
            }

            Label counter = FindName(order.Name + "counter") as Label;
            counter.Content = order.Count;

            Label price = FindName(order.Name + "price") as Label;
            price.Content = order.CalculatePrice();
        }

    }
}
