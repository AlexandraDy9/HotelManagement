using HotelManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement
{
    public class DeleteFeaturesFromRoomCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            if (parameter != null)
            {
                var values = ((object[])parameter);

                Room room = (Room)values[0];

                ListView FeaturesList = values[1] as ListView;
                List<Features> features = new List<Features>();

                foreach (Features item in FeaturesList.Items)
                {
                    if (item.Choosen != null)
                        features.Add(item);
                }

                foreach (Features item in features)
                {
                    try
                    {
                        using (SqlConnection myConnection = DALHelper.Connection)
                        {
                            SqlCommand myCommand = default(SqlCommand);

                            myCommand = new SqlCommand("DeleteRoomFeatures", myConnection)
                            {
                                CommandType = CommandType.StoredProcedure
                            };

                            SqlParameter uIdRoom = new SqlParameter("@IdRoom", room.IdRoom);
                            SqlParameter uIdFeature = new SqlParameter("@IdFeature", item.IdFeatures);

                            myCommand.Parameters.Add(uIdRoom);
                            myCommand.Parameters.Add(uIdFeature);

                            try
                            {
                                myConnection.Open();
                                myCommand.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message, "Error");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }

            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
