using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System;
using System.Collections.ObjectModel;

namespace HotelManagement
{
    public class EmployeeViewModel : ViewModelBase
    {
        private ObservableCollection<Room> rooms;
        private ObservableCollection<Reservation> reservations;
        private ObservableCollection<Sales> sales;
        private DateTime? selectedDateStart;
        private DateTime? selectedDateEnd;
        private Reservation selectedReservation;
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

        public ObservableCollection<Reservation> Reservations
        { get => reservations;
            set
            {
                reservations = value;
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

        public Reservation SelectedReservation
        {
            get => selectedReservation;
            set
            {
                selectedReservation = value;
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

        public LogOutCommand LogOutCommand { get; }
        public SearchRoomsAfterDate SearchRoomsAfterDate { get; }
        public ChangeStateOfReservationCommand ChangeStateOfReservationCommand { get; }
        public RoomDetailsCommand RoomDetailsCommand { get; }

        public EmployeeViewModel(User user)
        {
            User = user;
            Rooms = new ObservableCollection<Room>();
            Rooms = RoomDAL.GetAllRooms();

            Reservations = new ObservableCollection<Reservation>();
            Reservations = ReservationDAL.GetAllReservations();
            sales = new ObservableCollection<Sales>();

            LogOutCommand = new LogOutCommand();
            SearchRoomsAfterDate = new SearchRoomsAfterDate(Rooms, sales);
            ChangeStateOfReservationCommand = new ChangeStateOfReservationCommand();
            RoomDetailsCommand = new RoomDetailsCommand();
        }
    }
}
