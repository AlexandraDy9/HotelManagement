using HotelManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HotelManagement.DataAccessLayer
{
    public static class ReservationDAL
    {
        public static void ChangeReservationState(Reservation reservation, string type)
        {
            try
            {
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("ChangeReservationState", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter uId = new SqlParameter("@IdReservation", reservation.IdReservation);
                    SqlParameter uState = new SqlParameter("@State", type);

                    cmd.Parameters.Add(uId);
                    cmd.Parameters.Add(uState);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        public static void GetClientReservations(User User, ObservableCollection<Reservation> Reservations)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = new SqlCommand("GetAllReservationForClient", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter nIdUser = new SqlParameter("@Iduser", User.IdUser);

                    myCommand.Parameters.Add(nIdUser);

                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        Reservation reservation = new Reservation
                        {
                            IdReservation = reader.IsDBNull(0) ? -1 : (int)reader[0],
                            CheckIn = DateTime.Parse(reader[1].ToString()).Date,
                            CheckOut = DateTime.Parse(reader[2].ToString()).Date,
                            State = reader.IsDBNull(3) ? null : reader[3].ToString(),
                            IsDeleted = reader[4].Equals(0) ? false : true,
                            TotalPrice = reader.IsDBNull(5) ? 0.00 : (double)reader[5],
                            IdUser = reader.IsDBNull(6) ? -1 : (int)reader[6]
                        };
                        Reservations.Add(reservation);
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

        public static ObservableCollection<Reservation> GetAllReservations()
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = new SqlCommand("GetAllReservations", myConnection);
                    ObservableCollection<Reservation> result = new ObservableCollection<Reservation>();
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Connection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        Reservation reservation = new Reservation
                        {
                            IdReservation = reader.IsDBNull(0) ? -1 : (int)reader[0],
                            CheckIn = DateTime.Parse(reader[1].ToString()).Date,
                            CheckOut = DateTime.Parse(reader[2].ToString()).Date,
                            State = reader.IsDBNull(3) ? null : reader[3].ToString(),
                            IsDeleted = reader[4].Equals(0) ? false : true,
                            TotalPrice = reader.IsDBNull(5) ? 0.00 : (double)reader[5],
                            IdUser = reader.IsDBNull(6) ? -1 : (int)reader[6]
                        };

                        result.Add(reservation);
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

        public static void AddReservation(Reservation reservation)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = default(SqlCommand);

                    myCommand = new SqlCommand("InsertReservation", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter uCheckIn = new SqlParameter("@DateStart", reservation.CheckIn);
                    SqlParameter uCheckOut = new SqlParameter("@DateEnd", reservation.CheckOut);
                    SqlParameter uState = new SqlParameter("@State", reservation.State);
                    SqlParameter uTotalPrice = new SqlParameter("@TotalPrice", reservation.TotalPrice);
                    SqlParameter uIdUser = new SqlParameter("@IdUser", reservation.IdUser);


                    myCommand.Parameters.Add(uCheckIn);
                    myCommand.Parameters.Add(uCheckOut);
                    myCommand.Parameters.Add(uState);
                    myCommand.Parameters.Add(uTotalPrice);
                    myCommand.Parameters.Add(uIdUser);

                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        MessageBox.Show("Your reservation was booked.", "Info");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }

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


        public static void AddReservationsRoom(List<Room> room, Reservation reservation, Sales sale)
        {
            foreach (Room item in room)
            {
                try
                {
                    using (SqlConnection myConnection = DALHelper.Connection)
                    {
                        SqlCommand myCommand = default(SqlCommand);

                        myCommand = new SqlCommand("InsertReservationRoom", myConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        SqlParameter uIdReservation = new SqlParameter("@IdReservation", reservation.IdReservation);
                        SqlParameter uIdRoom = new SqlParameter("@IdRoom", item.IdRoom);
                        SqlParameter uNumber = new SqlParameter("@Number", Int32.Parse(item.Number));

                        int idSale = item.SetSales == true ? sale.IdSales : 0;

                        SqlParameter uIdSales = new SqlParameter("@IdSales", idSale);


                        myCommand.Parameters.Add(uIdReservation);
                        myCommand.Parameters.Add(uIdRoom);
                        myCommand.Parameters.Add(uNumber);
                        myCommand.Parameters.Add(uIdSales);

                        try
                        {
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }

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
        }

        public static void AddReservationServices(List<AdditionalServices> additionalServices, Reservation reservation)
        {
            foreach (AdditionalServices item in additionalServices)
            {
                try
                {
                    using (SqlConnection myConnection = DALHelper.Connection)
                    {
                        SqlCommand myCommand = default(SqlCommand);

                        myCommand = new SqlCommand("InsertReservationServices", myConnection)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        SqlParameter uIdReservation = new SqlParameter("@IdReservation", reservation.IdReservation);
                        SqlParameter uIdServices = new SqlParameter("@IdServices", item.IdServices);

                        myCommand.Parameters.Add(uIdReservation);
                        myCommand.Parameters.Add(uIdServices);

                        try
                        {
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }

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
        }
    }
}
