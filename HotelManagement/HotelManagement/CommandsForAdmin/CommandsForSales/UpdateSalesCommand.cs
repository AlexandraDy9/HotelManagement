using HotelManagement.DataAccessLayer;
using HotelManagement.Model;
using System;

namespace HotelManagement
{
    public class UpdateSalesCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = (object[])parameter;

                string name = values[0].ToString().Equals(null) ? "None" : values[0].ToString();
                string nName = values[1].ToString().Equals(null) ? "None" : values[1].ToString();
                DateTime nDateStart = (DateTime)values[2];
                DateTime nDateEnd = (DateTime)values[3];

                float nPrice = values[4].Equals(null) ? 0 : float.Parse(values[4].ToString());
                int nNumberOfDays = values[5].Equals(null) ? 0 : Int32.Parse(values[5].ToString());
                string nType = values[6].ToString().Equals(null) ? "None" : values[6].ToString();

                Sales sale = new Sales
                {
                    Name = nName,
                    DateStart = nDateStart,
                    DateEnd = nDateEnd,
                    Price = nPrice,
                    NumberOfDays = nNumberOfDays
                };

                SalesDAL.ModifySale(sale, name, nType);
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
