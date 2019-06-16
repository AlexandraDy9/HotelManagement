using System;

namespace HotelManagement.Model
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string State { get; set; }
        public double TotalPrice { get; set; }
        public int IdUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
