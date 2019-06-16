using HotelManagement.Model;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HotelManagement
{
    public class AddRoomPriceCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                float price = values[0].Equals(null) ? 0 : float.Parse(values[0].ToString());
                DateTime dateStart = (DateTime)values[1];
                DateTime dateEnd = (DateTime)values[2];
                Room room = (Room)values[3];
                string item = room.Type;

                try
                {
                    using (SqlConnection myConnection = DALHelper.Connection)
                    {
                        SqlCommand myCommand = default(SqlCommand);

                        myCommand = new SqlCommand("InsertRoomPrice", myConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        SqlParameter uPrice = new SqlParameter("@Price", price);
                        SqlParameter uDataStart = new SqlParameter("@DataStart", dateStart);
                        SqlParameter uDateEnd = new SqlParameter("@DataEnd", dateEnd);
                        SqlParameter uItem = new SqlParameter("@Item", item);

                        myCommand.Parameters.Add(uPrice);
                        myCommand.Parameters.Add(uDataStart);
                        myCommand.Parameters.Add(uDateEnd);
                        myCommand.Parameters.Add(uItem);

                        try
                        {
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
                MessageBox.Show("Nu intra");
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
