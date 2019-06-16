using System.Windows.Media.Imaging;

namespace HotelManagement.Model
{
    public class Room
    {
        public int IdRoom { get; set; }
        public string Type { get; set; }
        public int NumberOfRooms { get; set; }
        public BitmapImage Image { get; set; }
        public bool IsDeleted { get; set; }
        public double Price { get; set; }

        // number => to know how many different rooms are about to been used for reservation
        public string Number { get; set; }
        public bool SetSales { get; set; }
    }
}
