using HotelManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;


namespace HotelManagement.DataAccessLayer
{
    public static class AdditionalServicesDAL
    {
        public static ObservableCollection<AdditionalServices> GetAllAdditionalServices()
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = new SqlCommand("GetAllAdditionalServices", myConnection);
                    ObservableCollection<AdditionalServices> result = new ObservableCollection<AdditionalServices>();
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Connection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        AdditionalServices additionalService = new AdditionalServices
                        {
                            IdServices = reader.IsDBNull(0) ? -1 : (int)reader[0],
                            Name = reader.IsDBNull(1) ? null : reader[1].ToString().Replace("  ", string.Empty),
                            Price = reader.IsDBNull(2) ? 0.00 : (double)reader[2],
                            IsDeleted = reader[3].Equals(0) ? false : true,
                            Choosen = null
                        };

                        result.Add(additionalService);
                    }
                    reader.Close();

                    if (result.Count > 0)
                        return result;

                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return null;
        }


        public static void AddServices(string name)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = default(SqlCommand);

                    myCommand = new SqlCommand("InsertServices", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter uName = new SqlParameter("@Name", name);

                    myCommand.Parameters.Add(uName);

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

        public static void DeleteServices(string name)
        {
            try
            {
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteServices", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter paramName = new SqlParameter("@Name", name);

                    cmd.Parameters.Add(paramName);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public static void ModifyServices(string nameToSearch, string newName)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = default(SqlCommand);

                    myCommand = new SqlCommand("UpdateServices", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter uUsernameToSearch = new SqlParameter("@NameToSearch", nameToSearch);
                    SqlParameter uName = new SqlParameter("@Name", newName);

                    myCommand.Parameters.Add(uUsernameToSearch);
                    myCommand.Parameters.Add(uName);

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}

