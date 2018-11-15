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
            }
        }

        enum Category { Bestsellers, Burgers, Steaks, SaladSandwichs, AppetizersSoups, Omelettes, Kids, Drinks, DessertsShakes };
        Food[][] foods;

        Dictionary<string, double>[] ReqCus = { new Dictionary<string, double> {
                { "Large", 1.00 },
                { "Medium", 1.00 },
                { "Small", 1.00 }
            }
        };
        Dictionary<string, double>[] OptCus = { new Dictionary<string, double> {
                { "Cheese", 1.00 },
                { "Meat", 1.00 },
                { "Small", 1.00 }
            }
        };

        //Load hard coded food info
        private void LoadFood() {
            foods = new Food[10][];
            Food test = new Food("test", 100, "this is a test food", ReqCus, OptCus);
            Food test2 = new Food("test2", 100, "this is another test food", ReqCus, OptCus);
            Food test3 = new Food("test3", 100, "this is another test food", ReqCus, OptCus);
            Food test4 = new Food("test4", 100, "this is another test food", ReqCus, OptCus);
            Food test5 = new Food("test5", 100, "this is another test food", ReqCus, OptCus);
            foods[(int)Category.Bestsellers] = new[] { test, test2, test3, test4, test5 };
        }

        //Init a food in menu
        private void InitFood(Food f, int i) {
            Grid mg = new Grid();
            mg.Name = f.Name + "mg";
            mg.Width = double.NaN;
            mg.Height = 150;
            mg.Margin = new Thickness(10, 10, 10, 10);

            Border b = new Border();
            b.BorderBrush = System.Windows.Media.Brushes.Black;
            b.BorderThickness = new Thickness(2);
            mg.Children.Add(b);

            Grid g = new Grid();
            g.Name = f.Name + "g";
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
            btn.Name = f.Name;
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

        //Ecent handler
        private void MenuClicked(object sender, RoutedEventArgs e) {
            Button mg = sender as Button;
            Label icon = FindName(mg.Name + "Icon") as Label;
            if ((string)icon.Content == "Up") {
                icon.Content = "Down";
            } else {
                icon.Content = "Up";
            }
            Grid p = FindName("Pivot") as Grid;
            ScrollViewer sv = FindName("MenuSV") as ScrollViewer;
            Point pos = mg.TransformToAncestor(p).Transform(new Point(0, 0));
            sv.ScrollToVerticalOffset(pos.Y);
            MessageBox.Show(pos.Y + "");
        }
    }
}
