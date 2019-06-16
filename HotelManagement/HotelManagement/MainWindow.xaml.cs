using System.Windows;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void RegisterClick(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
            GridMain.Visibility = Visibility.Collapsed;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
            GridMain.Visibility = Visibility.Visible;
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            InputBoxUpdate.Visibility = Visibility.Visible;
            GridMain.Visibility = Visibility.Collapsed;
        }

        private void ButtonUpdateClick(object sender, RoutedEventArgs e)
        {
            InputBoxUpdate.Visibility = Visibility.Collapsed;
            GridMain.Visibility = Visibility.Visible;
        }
    }
}
