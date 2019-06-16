using HotelManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media.Imaging;

namespace HotelManagement.DataAccessLayer
{
    public static class RoomDAL
    {
        public static void GetAllAvailbleRooms(ObservableCollection<Room> Rooms, DateTime dateStart, DateTime dateEnd)
        {
            float days = (dateEnd - dateStart).Days;
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = new SqlCommand("GetAllAvailableRooms", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter checkIn = new SqlParameter("@Checkin", dateStart);
                    SqlParameter checkOut = new SqlParameter("@Checkout", dateEnd);

                    myCommand.Parameters.Add(checkIn);
                    myCommand.Parameters.Add(checkOut);

                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();

                    Rooms.Clear();
                    while (reader.Read())
                    {
                        Room room = new Room
                        {
                            IdRoom = reader.IsDBNull(0) ? -1 : (int)reader[0],
                            Type = reader.IsDBNull(1) ? null : reader[1].ToString(),
                            NumberOfRooms = reader.IsDBNull(2) ? 0 : (int)reader[2],
                            Image = reader.IsDBNull(3) ? null : new BitmapImage(new Uri(reader[3].ToString(), UriKind.Relative)),
                            IsDeleted = reader[4].Equals(0) ? false : true,
                            Price = reader.IsDBNull(5) ? 0.00 : (double)reader[5] * days,
                            Number = "0"
                        };
                        Rooms.Add(room);
                    }

                    reader.Close();

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
        }

        public static ObservableCollection<Room> GetAllRooms()
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = new SqlCommand("GetAllRooms", myConnection);
                    ObservableCollection<Room> result = new ObservableCollection<Room>();
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Connection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Room room = new Room
                        {
                            IdRoom = reader.IsDBNull(0) ? -1 : (int)reader[0],
                            Type = reader.IsDBNull(1) ? null : reader[1].ToString(),
                            NumberOfRooms = reader.IsDBNull(2) ? 0 : (int)reader[2],
                            Image = reader.IsDBNull(3) ? null : new BitmapImage(new Uri(reader[3].ToString(), UriKind.Relative)),
                            IsDeleted = reader[4].Equals(0) ? false : true,
                            Price = reader.IsDBNull(5) ? 0.00 : (double)reader[5]
                        };

                        result.Add(room);
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

        public static void AddRoom(Room room, string image)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = default(SqlCommand);

                    myCommand = new SqlCommand("InsertRoom", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter uType = new SqlParameter("@Type", room.Type);
                    SqlParameter uImage = new SqlParameter("@Image", image);
                    SqlParameter uNumber = new SqlParameter("@NumberOfRooms", room.NumberOfRooms);

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

        public static void DeleteRoom(Room room)
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

        public static void ModifyRoom(Room room, string type, int number)
        {
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
}
