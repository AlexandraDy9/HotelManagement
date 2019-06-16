using HotelManagement.DataAccessLayer;


namespace HotelManagement
{
    public class UpdateFeaturesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                string nameToSearch = values[0].ToString();
                string newName = values[1].ToString();

                FeaturesDAL.ModifyFeature(nameToSearch, newName);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}

