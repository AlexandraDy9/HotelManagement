using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace HotelManagement
{
    public class SearchRoomsAfterDate : CommandBase
    {
        private ObservableCollection<Room> Rooms;
        private ObservableCollection<Sales> Sales;

        public SearchRoomsAfterDate(ObservableCollection<Room> rooms, ObservableCollection<Sales> sales)
        {
            Rooms = rooms ?? throw new ArgumentNullException(nameof(rooms));
            Sales = sales ?? throw new ArgumentNullException(nameof(sales));
        }

        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                DateTime dateStart = (DateTime)values[0];
                DateTime dateEnd = (DateTime)values[1];

                if(dateStart > dateEnd || (dateStart < DateTime.Now && dateEnd < DateTime.Now))
                {
                    MessageBox.Show("Please enter valid dates", "Info");
                    return;
                }

                //rooms
                RoomDAL.GetAllAvailbleRooms(Rooms, dateStart, dateEnd);


                //sales for client
                SalesDAL.GetAllAvailableSales(dateStart, dateEnd, Sales);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

    }
}

