using HotelManagement.Model;
using System;
using System.Data;
using System.Data.SqlClient;
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
                    try
                    {
                        using (SqlConnection con = DALHelper.Connection)
                        {
                            SqlCommand cmd = new SqlCommand("DeleteRoom", con)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            SqlParameter paramIdRoom = new SqlParameter("@idRoom", room.IdRoom);

                            cmd.Parameters.Add(paramIdRoom);
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
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
