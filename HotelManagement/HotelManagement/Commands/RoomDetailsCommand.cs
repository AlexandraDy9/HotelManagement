using HotelManagement.Model;

namespace HotelManagement
{
    public class RoomDetailsCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is Room room)
            {
                RoomDetailsWindow roomDetailsWindow = new RoomDetailsWindow(room);
                roomDetailsWindow.Show();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
