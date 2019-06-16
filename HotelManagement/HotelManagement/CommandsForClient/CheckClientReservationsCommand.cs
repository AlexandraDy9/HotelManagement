using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System;
using System.Collections.ObjectModel;

namespace HotelManagement
{
    public class CheckClientReservationsCommand : CommandBase
    {
        private ObservableCollection<Reservation> Reservations;
        private User User;

        public CheckClientReservationsCommand(ObservableCollection<Reservation> reservations, User user)
        {
            Reservations = reservations ?? throw new ArgumentNullException(nameof(reservations));
            User = user;
        }

        public override void Execute(object parameter)
        {
            ReservationDAL.GetClientReservations(User, Reservations);
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

    }
}

