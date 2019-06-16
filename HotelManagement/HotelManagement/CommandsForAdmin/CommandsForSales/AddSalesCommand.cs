using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System;

namespace HotelManagement
{
    public class AddSalesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                string name = values[0].ToString().Equals(null) ? "None" : values[0].ToString();
                DateTime dateStart = (DateTime)values[1];
                DateTime dateEnd = (DateTime)values[2];

                float price = values[3].Equals(null) ? 0 : float.Parse(values[3].ToString());
                int numberOfDays = values[4].Equals(null) ? 0 : Int32.Parse(values[4].ToString());
                string type = values[5].ToString().Equals(null) ? "None" : values[5].ToString();

                Sales sale = new Sales
                {
                    Name = name,
                    DateStart = dateStart,
                    DateEnd = dateEnd,
                    Price = price,
                    NumberOfDays = numberOfDays
                };

                SalesDAL.AddSale(sale, type);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
