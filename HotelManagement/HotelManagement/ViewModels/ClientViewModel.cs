using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HotelManagement
{
    public class ClientViewModel : ViewModelBase
    {
        private ObservableCollection<Room> rooms;
        private ObservableCollection<AdditionalServices> additionalServices;
        private ObservableCollection<Sales> sales;
        private ObservableCollection<Reservation> reservations;
        private DateTime? selectedDateStart;
        private DateTime? selectedDateEnd;
        private Reservation selectedReservation;
        private User user;

        private List<int> selectedItem;
        private Sales selectedSale;

        public ObservableCollection<Room> Rooms
        {
            get => rooms;
            set
            {
                rooms = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AdditionalServices> AdditionalServices
        {
            get => additionalServices;
            set
            {
                additionalServices = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Sales> Sales
        {
            get => sales;
            set
            {
                sales = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Reservation> Reservations
        {
            get => reservations;
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

        public List<int> SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        public Sales SelectedSale
        {
            get => selectedSale;
            set
            {
                selectedSale = value;
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
        public NewReservationCommand NewReservationCommand { get; }
        public CheckClientReservationsCommand CheckClientReservationsCommand { get; }
        public ChangeStateOfReservationCommand ChangeStateOfReservationCommand { get; }
        public RoomDetailsCommand RoomDetailsCommand { get; }

        public ClientViewModel(User user)
        {
            User = user;
            Rooms = new ObservableCollection<Room>();
            Rooms = RoomDAL.GetAllRooms();

            SelectedItem = new List<int>();

            AdditionalServices = new ObservableCollection<AdditionalServices>();
            AdditionalServices = AdditionalServicesDAL.GetAllAdditionalServices();

            Sales = new ObservableCollection<Sales>();

            Reservations = new ObservableCollection<Reservation>();

            LogOutCommand = new LogOutCommand();
            SearchRoomsAfterDate = new SearchRoomsAfterDate(Rooms, Sales);
            NewReservationCommand = new NewReservationCommand(User);
            CheckClientReservationsCommand = new CheckClientReservationsCommand(Reservations, User);
            ChangeStateOfReservationCommand = new ChangeStateOfReservationCommand();
            RoomDetailsCommand = new RoomDetailsCommand();
        }
    }
}
