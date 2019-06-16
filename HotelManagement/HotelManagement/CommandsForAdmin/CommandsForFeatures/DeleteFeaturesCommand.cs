using HotelManagement.DataAccessLayer;
using System.Windows;


namespace HotelManagement
{
    public class DeleteFeaturesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter is string name)
            {
                if (name != null)
                {
                    FeaturesDAL.DeleteFeatures(name);
                    
                }
                else MessageBox.Show("Please enter the name of features you want to delete.", "Info");
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}


