using System.Windows;

namespace HotelManagement
{
    public class ExitCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            var window = parameter;
            ((Window)window).Hide();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
