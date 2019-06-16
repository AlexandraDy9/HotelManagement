using HotelManagement.DataAccessLayer;
using System.Windows;


namespace HotelManagement
{
    public class DeleteSalesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {

            if (parameter is string name)
            {
                if (name != null)
                {
                    SalesDAL.DeleteSale(name);
                }
                else MessageBox.Show("Please enter the name of additonal sale you want to delete.", "Info");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}

