using HotelManagement.Model;
using System;
using System.Data;
using System.Data.SqlClient;
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

                try
                {
                    using (SqlConnection con = DALHelper.Connection)
                    {
                        SqlCommand cmd = new SqlCommand("UpdateRoom", con)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        SqlParameter uType = new SqlParameter("@type", type);
                        SqlParameter uIdRoom = new SqlParameter("@idRoom", room.IdRoom);
                        SqlParameter uNoRooms = new SqlParameter("@numberOfRooms", number);

                        cmd.Parameters.Add(uType);
                        cmd.Parameters.Add(uIdRoom);
                        cmd.Parameters.Add(uNoRooms);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
