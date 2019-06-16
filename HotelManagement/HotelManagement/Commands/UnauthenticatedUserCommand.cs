using System.Windows;

namespace HotelManagement
{
    public class UnauthenticatedUserCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            UnauthenticatedUser sudokuWindow = new UnauthenticatedUser();
            sudokuWindow.Show();
            ((Window)parameter).Hide();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
