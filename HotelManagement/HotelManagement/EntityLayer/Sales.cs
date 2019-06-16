using System;

namespace HotelManagement.Model
{
    public class Sales
    {
        public int IdSales { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double Price { get; set; }
        public int NumberOfDays { get; set; }
        public int IdRoom { get; set; }
        public bool IsDeleted { get; set; }
    }
}
