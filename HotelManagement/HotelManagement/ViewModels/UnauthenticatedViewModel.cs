using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System;
using System.Collections.ObjectModel;

namespace HotelManagement
{
    public class UnauthenticatedViewModel : ViewModelBase
    {
        private ObservableCollection<Room> rooms;
        private ObservableCollection<Sales> sales;
        private DateTime? selectedDateStart;
        private DateTime? selectedDateEnd;

        public ObservableCollection<Room> Rooms
        {
            get => rooms;
            set
            {
                rooms = value;
                OnPropertyChanged();
            }
        }

        public DateTime? SelectedDateEnd
        {
            get => selectedDateEnd;
            set
            {
                selectedDateEnd = value;
                OnPropertyChanged();
            }
        }

        public DateTime? SelectedDateStart
        {
            get => selectedDateStart;
            set
            {
                selectedDateStart = value;
                OnPropertyChanged();
            }
        }

        public LogOutCommand LogOutCommand { get; }
        public SearchRoomsAfterDate SearchRoomsAfterDate { get; }
        public RoomDetailsCommand RoomDetailsCommand { get; }

        public UnauthenticatedViewModel()
        {
            Rooms = new ObservableCollection<Room>();
            Rooms = RoomDAL.GetAllRooms();
            sales = new ObservableCollection<Sales>();

            LogOutCommand = new LogOutCommand();
            SearchRoomsAfterDate = new SearchRoomsAfterDate(Rooms,sales);
            RoomDetailsCommand = new RoomDetailsCommand();
        }
    }
}
