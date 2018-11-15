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


        private void InitCustom(Food f, int i) {
            Grid cg = new Grid();
            cg.Width = Double.NaN;
            cg.Margin = new Thickness(15, 0, 15, 10);
            //cg.Visibility = Visibility.Collapsed;

            Border b = new Border();
            b.BorderBrush = System.Windows.Media.Brushes.Black;
            b.BorderThickness = new Thickness(2);
            cg.Children.Add(b);

            Grid g = new Grid();
            RowDefinition cr1 = new RowDefinition();
            cr1.Height = new GridLength(1, GridUnitType.Star);
            RowDefinition cr2 = new RowDefinition();
            cr2.Height = new GridLength(2, GridUnitType.Star);
            g.RowDefinitions.Add(cr1);
            g.RowDefinitions.Add(cr2);

            ColumnDefinition cc1 = new ColumnDefinition();
            cc1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition cc2 = new ColumnDefinition();
            cc2.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition cc3 = new ColumnDefinition();
            cc2.Width = new GridLength(1, GridUnitType.Star);
            g.ColumnDefinitions.Add(cc1);
            g.ColumnDefinitions.Add(cc2);
            g.ColumnDefinitions.Add(cc3);

        }
        //Customization section
        /**
        

        Label desc = new Label();
        name.Margin = new Thickness(10, 10, 10, 10);
        name.SetValue(Grid.ColumnSpanProperty, 3);
        name.SetValue(Grid.RowProperty, 1);
        name.Content = foods[(int)category][i].Description;
        g2.Children.Add(desc);

        Label priceChange = new Label();
        price.Margin = new Thickness(10, 10, 10, 10);
        price.SetValue(Grid.ColumnProperty, 2);
        price.Content = foods[(int)category][i].Price;
        g2.Children.Add(price);
        **/
    }
}
