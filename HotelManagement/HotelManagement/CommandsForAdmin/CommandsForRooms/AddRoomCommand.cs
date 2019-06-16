using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System;

namespace HotelManagement
{
    public class AddRoomCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = (object[])parameter;

                string type = values[0].ToString().Equals(null) ? "None" : char.ToUpper(values[0].ToString()[0]) + values[0].ToString().Substring(1);

                type.Trim();

                int number = values[1].Equals(null) ? 0 : Int32.Parse(values[3].ToString());
                string image = values[2].ToString().Equals(null) ? "None" : "Images/" + values[2].ToString();

                Room room = new Room
                {
                    Type = type,
                    NumberOfRooms = number
                };

                RoomDAL.AddRoom(room, image);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
