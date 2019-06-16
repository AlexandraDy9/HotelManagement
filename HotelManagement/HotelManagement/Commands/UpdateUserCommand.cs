using HotelManagement.DataAccessLayer;

namespace HotelManagement
{
    public class UpdateUserCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                string usernameToSearch = values[0].ToString();
                string newUsername = values[1].ToString();
                string newPassword = values[2].ToString();

                UserDAL.ModifyUser(usernameToSearch, newPassword, newUsername);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
