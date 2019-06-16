using System.Windows;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow(User user)
        {
            InitializeComponent();
            DataContext = new ClientViewModel(user);

            DatePickerCheckIn.BlackoutDates.AddDatesInPast();
            DatePickerCheckOut.BlackoutDates.AddDatesInPast();
        }

        private void NewReservationClick(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
        }


        private void ChangeReservationClick(object sender, RoutedEventArgs e)
        {
            InputBox2.Visibility = Visibility.Visible;
        }

        private void ButtonChangeClick(object sender, RoutedEventArgs e)
        {
            InputBox2.Visibility = Visibility.Collapsed;
        }
    }
}
