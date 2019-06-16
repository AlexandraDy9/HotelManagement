using HotelManagement.DataAccessLayer;

namespace HotelManagement
{
    public class AddFeaturesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                string name = parameter.ToString();

                FeaturesDAL.AddFeature(name);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}

