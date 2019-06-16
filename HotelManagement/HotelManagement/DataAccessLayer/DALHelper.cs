using System.Data.SqlClient;

namespace HotelManagement
{
    static class DALHelper
    {
        private static readonly string connectionString = @"Data Source=DESKTOP-H90E2KJ\SQLEXPRESS;Initial Catalog=HotelDataBase;Integrated Security=True";

        internal static SqlConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}