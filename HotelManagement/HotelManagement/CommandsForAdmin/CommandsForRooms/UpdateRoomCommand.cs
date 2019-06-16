using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System;
using System.Windows;

namespace HotelManagement
{
    public class UpdateRoomCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                Room room = (Room)values[0];

                string type = values[1].Equals(null) ? room.Type : char.ToUpper(values[1].ToString()[0]) + values[1].ToString().Substring(1);

                type.Trim();
                if (!type.Equals("Single") || !type.Equals("Double") ||
                    !type.Equals("Twin") || !type.Equals("Triple") ||
                    !type.Equals("Deluxe") || !type.Equals("Cvadrupla"))
                {
                    MessageBox.Show("Please enter a valid type of room. \nExemple: Twin, Double, Triple, Single, Deluxe, Cvadrupla. ", "Info");
                    return;
                }

                int number = values[2].Equals(null) ? room.NumberOfRooms : Int32.Parse(values[2].ToString());

                RoomDAL.ModifyRoom(room, type, number);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
