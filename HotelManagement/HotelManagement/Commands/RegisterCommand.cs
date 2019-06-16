using HotelManagement.DataAccessLayer;

namespace HotelManagement
{
    public class RegisterCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                string username = values[0].ToString();
                string password = values[1].ToString();

                User user = new User
                {
                    Name = username,
                    Password = password,
                    Role = 2
                };

                UserDAL.AddPerson(user);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
