using HotelManagement.DataAccessLayer;

namespace HotelManagement
{
    public class AddServicesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                string name = parameter.ToString();

                AdditionalServicesDAL.AddServices(name);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
