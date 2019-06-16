using HotelManagement.DataAccessLayer;
using System.Windows;


namespace HotelManagement
{
    public class DeleteServicesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is string name)
            {
                if (name != null)
                {
                    AdditionalServicesDAL.DeleteServices(name);
                }
                else MessageBox.Show("Please enter the name of additonal service you want to delete.", "Info");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}

