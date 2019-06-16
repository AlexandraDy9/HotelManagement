using System.Windows;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow(User user)
        {
            InitializeComponent();
            DataContext = new EmployeeViewModel(user);

            DatePickerCheckIn.BlackoutDates.AddDatesInPast();
            DatePickerCheckOut.BlackoutDates.AddDatesInPast();
        }

        private void ChangeStateClick(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
        }
    }
}
