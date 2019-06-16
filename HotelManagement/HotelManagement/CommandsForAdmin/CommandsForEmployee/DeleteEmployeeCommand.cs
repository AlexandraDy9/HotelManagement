using HotelManagement.DataAccessLayer;
using System.Windows;

namespace HotelManagement
{
    public class DeleteEmployeeCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is string username)
            {
                if (username != null)
                {
                    User user = new User
                    {
                        Name = username
                    };

                    UserDAL.DeleteUser(user);
                }
                else MessageBox.Show("Please enter the username you want to delete.", "Info");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
