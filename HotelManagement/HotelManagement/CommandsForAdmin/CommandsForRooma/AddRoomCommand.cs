using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HotelManagement
{
    public class AddRoomCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                string type = values[0].ToString().Equals(null) ? "None" : char.ToUpper(values[0].ToString()[0]) + values[0].ToString().Substring(1);

                type.Trim();

                int number = values[1].Equals(null) ? 0 : Int32.Parse(values[3].ToString());
                string image = values[2].ToString().Equals(null) ? "None" : "Images/" + values[2].ToString();

                try
                {
                    using (SqlConnection myConnection = DALHelper.Connection)
                    {
                        SqlCommand myCommand = default(SqlCommand);

                        myCommand = new SqlCommand("InsertRoom", myConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        SqlParameter uType = new SqlParameter("@Type", type);
                        SqlParameter uImage = new SqlParameter("@Image", image);
                        SqlParameter uNumber = new SqlParameter("@NumberOfRooms", number);

                        myCommand.Parameters.Add(uType);
                        myCommand.Parameters.Add(uImage);
                        myCommand.Parameters.Add(uNumber);

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
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
