using HotelManagement.DataAccessLayer;
using HotelManagement.Model;

namespace HotelManagement
{
    public class ChangeStateOfReservationCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = (object[])parameter;

                Reservation reservation = (Reservation)values[0];

                string type = values[1].Equals(null) ? reservation.State : values[1].ToString();

                ReservationDAL.ChangeReservationState(reservation, type);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
