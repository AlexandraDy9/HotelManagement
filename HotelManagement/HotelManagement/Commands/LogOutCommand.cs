using System.Windows;

namespace HotelManagement
{
    public class LogOutCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var window = parameter;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            ((Window)window).Hide();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
