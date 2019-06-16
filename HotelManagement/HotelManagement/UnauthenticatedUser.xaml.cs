using System.Windows;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for UnauthenticatedUser.xaml
    /// </summary>
    public partial class UnauthenticatedUser : Window
    {
        public UnauthenticatedUser()
        {
            InitializeComponent();

            DatePickerCheckIn.BlackoutDates.AddDatesInPast();
            DatePickerCheckOut.BlackoutDates.AddDatesInPast();
        }
    }
}
