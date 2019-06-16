using HotelManagement.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelManagement
{
    public class NewReservationCommand : CommandBase
    {
        private User User;

        public NewReservationCommand(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                DateTime dateStart = (DateTime)values[0];
                DateTime dateEnd = (DateTime)values[1];

                Sales sale = (Sales)values[2];
                var numberOfPersons = values[3].ToString();

                ListView RoomList = values[4] as ListView;
                List<Room> room = new List<Room>();

                ListView AdditionalServicesList = values[5] as ListView;
                List<AdditionalServices> additionalServices = new List<AdditionalServices>();

                foreach (Room item in RoomList.Items)
                {
                    if (item.Number != "0")
                        room.Add(item);
                    if (Int32.Parse(item.Number) > 3)
                    {
                        MessageBox.Show("The maxim number of rooms for booking is 3.", "Info");
                        return;
                    }
                }

                foreach (AdditionalServices item in AdditionalServicesList.Items)
                {
                    if (item.Choosen != null)
                        additionalServices.Add(item);
                }


                string totalPrice = "Number of persons: " + numberOfPersons + "\n";

                if (sale != null)
                {
                    float days = (dateEnd - dateStart).Days;
                    if (sale.NumberOfDays == days)
                    {
                        foreach (Room item in room)
                        {
                            if (item.IdRoom == sale.IdRoom)
                            {
                                totalPrice += "Sale will be applied for the " + item.Type.Trim() + " room.";
                                item.Price = sale.Price;
                                item.SetSales = true;
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("The selected sale is available for " + sale.NumberOfDays + " days", "Info");
                    }
                }

                Reservation reservation = new Reservation
                {
                    CheckIn = dateStart,
                    CheckOut = dateEnd,
                    IdUser = User.IdUser,
                    State = "activ"
                };

                totalPrice += "\n";
                foreach (Room item in room)
                {
                    totalPrice += "\nThe room: " + item.Type.Trim() + " has the final price: " + item.Price * Int32.Parse(item.Number);
                    reservation.TotalPrice += item.Price * Int32.Parse(item.Number);
                }

                totalPrice += "\n";
                foreach (AdditionalServices item in additionalServices)
                {
                    totalPrice += "\nAdditional services: " + item.Name;
                    reservation.TotalPrice += item.Price;
                }

                totalPrice += "\n";
                totalPrice += "\nTotal price: " + reservation.TotalPrice;

                MessageBox.Show(totalPrice, "Reservation");



                //add in dataBase the reservation
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


                //get the idReservation
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
                            Reservation res = new Reservation
                            {
                                IdReservation = reader.IsDBNull(0) ? -1 : (int)reader[0],
                                CheckIn = DateTime.Parse(reader[1].ToString()).Date,
                                CheckOut = DateTime.Parse(reader[2].ToString()).Date,
                                State = reader.IsDBNull(3) ? null : reader[3].ToString(),
                                IsDeleted = reader[4].Equals(0) ? false : true,
                                TotalPrice = reader.IsDBNull(5) ? 0.00 : (double)reader[5],
                                IdUser = reader.IsDBNull(6) ? -1 : (int)reader[6]
                            };

                            result.Add(res);
                        }
                        reader.Close();

                        if (result.Count > 0)
                            reservation.IdReservation = result.Last().IdReservation;

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
                                //MessageBox.Show(ex.Message, "Error");
                            }

                            if (myConnection.State == ConnectionState.Open)
                            {
                                myConnection.Dispose();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message, "Error");
                    }
                }


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
                               // MessageBox.Show(ex.Message, "Error");
                            }

                            if (myConnection.State == ConnectionState.Open)
                            {
                                myConnection.Dispose();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
