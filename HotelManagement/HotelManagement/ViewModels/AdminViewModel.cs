using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System.Collections.ObjectModel;

namespace HotelManagement
{
    public class AdminViewModel : ViewModelBase
    {
        private ObservableCollection<Room> rooms;
        private ObservableCollection<Features> features;
        private Room selectedRoom;
        private User user;

        public ObservableCollection<Room> Rooms
        {
            get => rooms;
            set
            {
                rooms = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Features> Features
        {
            get => features;
            set
            {
                features = value;
                OnPropertyChanged();
            }
        }

        public Room SelectedRoom
        {
            get => selectedRoom;
            set
            {
                selectedRoom = value;
                OnPropertyChanged();
            }
        }

        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
            }
        }

        public AddRoomCommand AddRoomCommand { get; }
        public DeleteRoomCommand DeleteRoomCommand { get; }
        public UpdateRoomCommand UpdateRoomCommand { get; }

        public AddEmployeeCommand AddEmployeeCommand { get; }
        public UpdateEmployeeCommand UpdateEmployeeCommand { get; }
        public DeleteEmployeeCommand DeleteEmployeeCommand { get; }

        public AddFeaturesCommand AddFeaturesCommand { get; }
        public UpdateFeaturesCommand UpdateFeaturesCommand { get; }
        public DeleteFeaturesCommand DeleteFeaturesCommand { get; }

        public AddServicesCommand AddServicesCommand { get; }
        public UpdateServicesCommand UpdateServicesCommand { get; }
        public DeleteServicesCommand DeleteServicesCommand { get; }

        public AddSalesCommand AddSalesCommand { get; }
        public UpdateSalesCommand UpdateSalesCommand { get; }
        public DeleteSalesCommand DeleteSalesCommand { get; }

        public AddRoomPriceCommand AddRoomPriceCommand { get; }
        public AddServicePriceCommand AddServicePriceCommand { get; }

        public AddFeaturesToRoomCommand AddFeaturesToRoomCommand { get; }
        public DeleteFeaturesFromRoomCommand DeleteFeaturesFromRoomCommand { get; }

        public LogOutCommand LogOutCommand { get; }
        public RoomDetailsCommand RoomDetailsCommand { get; }


        public AdminViewModel(User user)
        {
            User = user;
            Rooms = new ObservableCollection<Room>();
            Rooms = RoomDAL.GetAllRooms();

            Features = new ObservableCollection<Features>();
            Features = FeaturesDAL.GetAllFeatures();

            AddRoomCommand = new AddRoomCommand();
            DeleteRoomCommand = new DeleteRoomCommand();
            UpdateRoomCommand = new UpdateRoomCommand();

            AddEmployeeCommand = new AddEmployeeCommand();
            UpdateEmployeeCommand = new UpdateEmployeeCommand();
            DeleteEmployeeCommand = new DeleteEmployeeCommand();

            AddFeaturesCommand = new AddFeaturesCommand();
            UpdateFeaturesCommand = new UpdateFeaturesCommand();
            DeleteFeaturesCommand = new DeleteFeaturesCommand();

            AddServicesCommand = new AddServicesCommand();
            UpdateServicesCommand = new UpdateServicesCommand();
            DeleteServicesCommand = new DeleteServicesCommand();

            AddSalesCommand = new AddSalesCommand();
            UpdateSalesCommand = new UpdateSalesCommand();
            DeleteSalesCommand = new DeleteSalesCommand();

            AddRoomPriceCommand = new AddRoomPriceCommand();
            AddServicePriceCommand = new AddServicePriceCommand();

            AddFeaturesToRoomCommand = new AddFeaturesToRoomCommand();
            DeleteFeaturesFromRoomCommand = new DeleteFeaturesFromRoomCommand();

            LogOutCommand = new LogOutCommand();
            RoomDetailsCommand = new RoomDetailsCommand();

        }
    }
}
