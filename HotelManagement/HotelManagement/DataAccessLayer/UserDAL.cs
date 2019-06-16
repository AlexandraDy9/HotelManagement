using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace HotelManagement.DataAccessLayer
{
    public static class UserDAL
    {
        public static void AddPerson(User user)
        {
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = default(SqlCommand);

                    myCommand = new SqlCommand("InsertUser", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter uUsername = new SqlParameter("@Username", user.Name);
                    SqlParameter uPassword = new SqlParameter("@Password", user.Password);
                    SqlParameter uIdRole = new SqlParameter("@IdRole", user.Role);


                    myCommand.Parameters.Add(uUsername);
                    myCommand.Parameters.Add(uPassword);
                    myCommand.Parameters.Add(uIdRole);

                    try
                    {
                        myConnection.Open();
                        myCommand.ExecuteNonQuery();
                        MessageBox.Show("You have successfully register " + user.Name);
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

        public static void LoginUser(User logUser, object window)
        {
            User user = new User();
            using (SqlConnection myConnection = DALHelper.Connection)
            {
                SqlCommand myCommand = default(SqlCommand);

                myCommand = new SqlCommand("GetUser", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter uName = new SqlParameter("@Username", logUser.Name);
                SqlParameter uPassword = new SqlParameter("@Password", logUser.Password);

                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);

                myConnection.Open();
                myCommand.ExecuteNonQuery();

                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    user.IdUser = myReader.GetInt32(myReader.GetOrdinal("IdUser"));
                    user.Name = myReader.GetString(myReader.GetOrdinal("Username"));
                    user.Password = myReader.GetString(myReader.GetOrdinal("Password"));

                    user.Role = myReader.GetInt32(myReader.GetOrdinal("IdRole"));

                    switch (user.Role)
                    {
                        case 1:
                            {
                                AdminWindow adminWindow = new AdminWindow(user);
                                adminWindow.Show();
                                ((Window)window).Hide();
                                break;
                            }
                        case 2:
                            {
                                ClientWindow clientWindow = new ClientWindow(user);
                                clientWindow.Show();
                                ((Window)window).Hide();
                                break;
                            }
                        case 3:
                            {
                                EmployeeWindow employeeWindow = new EmployeeWindow(user);
                                employeeWindow.Show();
                                ((Window)window).Hide();
                                break;
                            }
                    }

                    // MessageBox.Show("You have logged in successfully " + username);
                }

                else
                {
                    MessageBox.Show("Login Failed...Try again !", "Login Denied");

                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
            }
        }

        public static void DeleteUser(User user)
        {
            try
            {
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("DeleteUser", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlParameter paramName = new SqlParameter("@UsernameToSearch", user.Name);

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

        public static void ModifyUser(string usernameToSearch, string newPassword, string newUsername)
        {
            User user = new User();
            try
            {
                using (SqlConnection myConnection = DALHelper.Connection)
                {
                    SqlCommand myCommand = default(SqlCommand);

                    myCommand = new SqlCommand("UpdateUser", myConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    SqlParameter uUsernameToSearch = new SqlParameter("@UsernameToSearch", usernameToSearch);
                    SqlParameter uName = new SqlParameter("@Username", newUsername);
                    SqlParameter uPassword = new SqlParameter("@Password", newPassword);

                    myCommand.Parameters.Add(uUsernameToSearch);
                    myCommand.Parameters.Add(uName);
                    myCommand.Parameters.Add(uPassword);

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
