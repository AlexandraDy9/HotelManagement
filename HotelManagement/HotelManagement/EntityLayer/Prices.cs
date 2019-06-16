using System;

namespace HotelManagement.Model
{
    public class Prices
    {
        public int IdPrices { get; set; }
        public float Value { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool IsDeleted { get; set; }
        public int IdServices { get; set; }
        public int IdRoom { get; set; }
    }
}
