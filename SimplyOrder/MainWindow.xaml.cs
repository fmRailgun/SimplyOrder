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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimplyOrder {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            LoadFood();
            InitializeComponent();
            InitMenu(Category.Bestsellers);
            Storyboard sb = this.FindResource("TaptoStart") as Storyboard; //by David Ledo (davidledo.com/cpsc481/#!blemd-intro.md)
            sb.Completed += OnStoryboardCompleted; //also by David Ledo
        }

        //This method is by David Ledo (davidledo.com/cpsc481/#!blemd-intro.md)
        private void OnStoryboardCompleted(object sender, EventArgs e)
        {
            this.SplashGrid.Visibility = Visibility.Hidden;
        }

        private void MenuSV_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }

        private void ScrollViewer_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            IEnumerable<Button> buttonList = grid1.Children.OfType<Button>();
            foreach(Button bb in buttonList)
            {
                bb.Background = new SolidColorBrush(Color.FromRgb(177, 17, 22));
            }
            Button b = (Button)sender;
            b.Background = new SolidColorBrush(Color.FromRgb(237, 28, 36));
            
        }
    }

    }
