using HotelManagement.DataAccessLayer;
using System.Windows.Controls;

namespace HotelManagement
{
    public class LoginCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                string username = values[0].ToString();
                var passwordBox = values[1] as PasswordBox;
                string password = passwordBox.Password.ToString();

                var window = values[2];

                User user = new User
                {
                    Name = username,
                    Password = password,
                };

                UserDAL.LoginUser(user, window);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
