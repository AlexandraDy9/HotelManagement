using HotelManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HotelManagement.DataAccessLayer
{
    public static class FeaturesDAL
    {
        public static ObservableCollection<string> GetFeaturesWithStringList(Room room)
        {
            try
            {
                SqlConnection myConnection = DALHelper.Connection;
                try
                {
                    SqlCommand myCommand = new SqlCommand("GetFeaturesForRoom", myConnection);
                    ObservableCollection<string> features = new ObservableCollection<string>();
                    myCommand.CommandType = CommandType.StoredProcedure;

                    SqlParameter idRoom = new SqlParameter("@IdRoom", SqlDbType.Int);
                    idRoom.Value = room.IdRoom;
                    myCommand.Parameters.Add(idRoom);

                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        features.Add(reader[0].ToString());
                    }
                    reader.Close();

                    if (features.Count > 0)
                        return features;

                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }
                }
                finally
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return null;
        }

        public static ObservableCollection<Features> GetAllFeatures()
        {
            try
            {
                SqlConnection myConnection = DALHelper.Connection;
                try
                {
                    SqlCommand myCommand = new SqlCommand("GetAllFeatures", myConnection);
                    ObservableCollection<Features> features = new ObservableCollection<Features>();
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Features feature = new Features
                        {
                            IdFeatures = reader.IsDBNull(0) ? -1 : (int)reader[0],
                            Name = reader.IsDBNull(1) ? null : reader[1].ToString().Replace("  ", string.Empty),
                            IsDeleted = reader[2].Equals(0) ? false : true
                        };
                        features.Add(feature);
                    }
                    reader.Close();

                    if (features.Count > 0)
                        return features;

                    if (myConnection.State == ConnectionState.Open)
                    {
                        myConnection.Dispose();
                    }
                }
                finally
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return null;
        }

        public static void AddFeature(string name)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = default(SqlCommand);

                    myCommand = new SqlCommand("InsertFeatures", myConnection)
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

        public static void DeleteFeatures(string name)
        {
            try
            {
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteFeatures", con)
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

        public static void ModifyFeature(string nameToSearch, string newName)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = default(SqlCommand);

                    myCommand = new SqlCommand("UpdateFeatures", myConnection)
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

