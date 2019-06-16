using HotelManagement.Model;
using System.Windows;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for RoomDetailsWindow.xaml
    /// </summary>
    public partial class RoomDetailsWindow : Window
    {
        public RoomDetailsWindow(Room room)
        {
            InitializeComponent();
            DataContext = new RoomDetailsViewModel(room);
        }
    }
}
