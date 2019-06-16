using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System.Collections.ObjectModel;

namespace HotelManagement
{
    public class RoomDetailsViewModel : ViewModelBase
    {
        private Room room;
        private ObservableCollection<string> features;

        public Room Room
        {
            get => room;
            set
            {
                room = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Features
        {
            get => features;
            set
            {
                features = value;
                OnPropertyChanged();
            }
        }

        public RoomDetailsViewModel(Room room)
        {
            Room = room;
            Features = FeaturesDAL.GetFeaturesWithStringList(Room);
        }
    }
}
