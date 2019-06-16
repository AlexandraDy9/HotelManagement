using HotelManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HotelManagement.DataAccessLayer
{
    public static class SalesDAL
    {
        public static void GetAllAvailableSales(DateTime dateStart, DateTime dateEnd, ObservableCollection<Sales> Sales)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = new SqlCommand("GetAllAvailableSales", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter checkIn = new SqlParameter("@Checkin", dateStart);
                    SqlParameter checkOut = new SqlParameter("@Checkout", dateEnd);

                    myCommand.Parameters.Add(checkIn);
                    myCommand.Parameters.Add(checkOut);

                    myConnection.Open();
                    SqlDataReader reader = myCommand.ExecuteReader();

                    Sales.Clear();
                    while (reader.Read())
                    {
                        Sales sale = new Sales
                        {
                            IdSales = reader.IsDBNull(0) ? -1 : (int)reader[0],
                            Name = reader.IsDBNull(1) ? null : reader[1].ToString().Trim() + " (" + reader[2].ToString() + " lei)" + ", " + reader[5].ToString() + " zile",
                            Price = reader.IsDBNull(2) ? 0.00 : (double)reader[2],
                            DateStart = DateTime.Parse(reader[3].ToString()),
                            DateEnd = DateTime.Parse(reader[4].ToString()),
                            NumberOfDays = reader.IsDBNull(5) ? -1 : (int)reader[5],
                            IdRoom = reader.IsDBNull(6) ? -1 : (int)reader[6],
                            IsDeleted = reader[7].Equals(0) ? false : true,
                        };

                        Sales.Add(sale);
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

        public static void AddSale(Sales sales, string roomType)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = default(SqlCommand);

                    myCommand = new SqlCommand("InsertSales", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter uName = new SqlParameter("@Name", sales.Name);
                    SqlParameter uDataStart = new SqlParameter("@DataStart", sales.DateStart);
                    SqlParameter uDateEnd = new SqlParameter("@DataEnd", sales.DateEnd);
                    SqlParameter uPrice = new SqlParameter("@Price", sales.Price);
                    SqlParameter uNumberOfDays = new SqlParameter("@NumberOfDays", sales.NumberOfDays);
                    SqlParameter uType = new SqlParameter("@Type", roomType);

                    myCommand.Parameters.Add(uName);
                    myCommand.Parameters.Add(uDataStart);
                    myCommand.Parameters.Add(uDateEnd);
                    myCommand.Parameters.Add(uPrice);
                    myCommand.Parameters.Add(uNumberOfDays);
                    myCommand.Parameters.Add(uType);

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

        public static void DeleteSale(string name)
        {
            try
            {
                MessageBox.Show(name);
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteSales", con)
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

        public static void ModifySale(Sales sale, string saleName, string roomType)
        {
            try
            {
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("UpdateSales", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter uName = new SqlParameter("@Name", saleName);
                    SqlParameter uNewName = new SqlParameter("@NewName", sale.Name);
                    SqlParameter uDataStart = new SqlParameter("@DataStart", sale.DateStart);
                    SqlParameter uDateEnd = new SqlParameter("@DataEnd", sale.DateEnd);
                    SqlParameter uPrice = new SqlParameter("@Price", sale.Price);
                    SqlParameter uNumberOfDays = new SqlParameter("@NumberOfDays", sale.NumberOfDays);
                    SqlParameter uType = new SqlParameter("@Type", roomType);

                    cmd.Parameters.Add(uName);
                    cmd.Parameters.Add(uNewName);
                    cmd.Parameters.Add(uDataStart);
                    cmd.Parameters.Add(uDateEnd);
                    cmd.Parameters.Add(uPrice);
                    cmd.Parameters.Add(uNumberOfDays);
                    cmd.Parameters.Add(uType);

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

