using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System.Windows;

namespace HotelManagement
{
    public class DeleteRoomCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is Room room)
            {
                if (room != null)
                {
                    RoomDAL.DeleteRoom(room);
                }
                else MessageBox.Show("Please select a room", "Info");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
