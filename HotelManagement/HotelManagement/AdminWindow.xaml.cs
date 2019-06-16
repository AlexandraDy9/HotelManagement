using System.Windows;

namespace HotelManagement
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow(User user)
        {
            InitializeComponent();
            DataContext = new AdminViewModel(user);
        }

        //Rooms
        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Collapsed;
        }

        private void UpdateRoomClick(object sender, RoutedEventArgs e)
        {
            InputBoxUpdate.Visibility = Visibility.Visible;
        }

        private void ButtonUpdateClick(object sender, RoutedEventArgs e)
        {
            InputBoxUpdate.Visibility = Visibility.Collapsed;
        }


        //Employee
        private void AddEmployeeClick(object sender, RoutedEventArgs e)
        {
            InputBoxEmployeeAdd.Visibility = Visibility.Visible;
        }

        private void ButtonAddEmployeeClick(object sender, RoutedEventArgs e)
        {
            InputBoxEmployeeAdd.Visibility = Visibility.Collapsed;
        }

        private void UpdateEmployeeClick(object sender, RoutedEventArgs e)
        {
            InputBoxEmployeeUpdate.Visibility = Visibility.Visible;
        }

        private void ButtonUpdateEmployeeClick(object sender, RoutedEventArgs e)
        {
            InputBoxEmployeeUpdate.Visibility = Visibility.Collapsed;
        }

        private void DeleteEmployeeClick(object sender, RoutedEventArgs e)
        {
            InputBoxEmployeeDelete.Visibility = Visibility.Visible;
        }

        private void ButtonDeleteEmployeeClick(object sender, RoutedEventArgs e)
        {
            InputBoxEmployeeDelete.Visibility = Visibility.Collapsed;
        }


        //Features
        private void AddFeaturesClick(object sender, RoutedEventArgs e)
        {
            InputBoxFeaturesAdd.Visibility = Visibility.Visible;
        }

        private void ButtonAddFeaturesClick(object sender, RoutedEventArgs e)
        {
            InputBoxFeaturesAdd.Visibility = Visibility.Collapsed;
        }

        private void UpdateFeaturesClick(object sender, RoutedEventArgs e)
        {
            InputBoxFeaturesUpdate.Visibility = Visibility.Visible;
        }

        private void ButtonUpdateFeaturesClick(object sender, RoutedEventArgs e)
        {
            InputBoxFeaturesUpdate.Visibility = Visibility.Collapsed;
        }

        private void DeleteFeaturesClick(object sender, RoutedEventArgs e)
        {
            InputBoxFeaturesDelete.Visibility = Visibility.Visible;
        }

        private void ButtonDeleteFeaturesClick(object sender, RoutedEventArgs e)
        {
            InputBoxFeaturesDelete.Visibility = Visibility.Collapsed;
        }



        //Services
        private void AddServicesClick(object sender, RoutedEventArgs e)
        {
            InputBoxServicesAdd.Visibility = Visibility.Visible;
        }

        private void ButtonAddServicesClick(object sender, RoutedEventArgs e)
        {
            InputBoxServicesAdd.Visibility = Visibility.Collapsed;
        }

        private void UpdateServicesClick(object sender, RoutedEventArgs e)
        {
            InputBoxServicesUpdate.Visibility = Visibility.Visible;
        }

        private void ButtonUpdateServicesClick(object sender, RoutedEventArgs e)
        {
            InputBoxServicesUpdate.Visibility = Visibility.Collapsed;
        }

        private void DeleteServicesClick(object sender, RoutedEventArgs e)
        {
            InputBoxServicesDelete.Visibility = Visibility.Visible;
        }

        private void ButtonDeleteServicesClick(object sender, RoutedEventArgs e)
        {
            InputBoxServicesDelete.Visibility = Visibility.Collapsed;
        }

        //Sales
        private void AddSalesClick(object sender, RoutedEventArgs e)
        {
            InputBoxSalesAdd.Visibility = Visibility.Visible;
        }

        private void ButtonAddSalesClick(object sender, RoutedEventArgs e)
        {
            InputBoxSalesAdd.Visibility = Visibility.Collapsed;
        }

        private void UpdateSalesClick(object sender, RoutedEventArgs e)
        {
            InputBoxSalesUpdate.Visibility = Visibility.Visible;
        }

        private void ButtonUpdateSalesClick(object sender, RoutedEventArgs e)
        {
            InputBoxSalesUpdate.Visibility = Visibility.Collapsed;
        }

        private void DeleteSalesClick(object sender, RoutedEventArgs e)
        {
            InputBoxSalesDelete.Visibility = Visibility.Visible;
        }

        private void ButtonDeleteSalesClick(object sender, RoutedEventArgs e)
        {
            InputBoxSalesDelete.Visibility = Visibility.Collapsed;
        }


        //Prices

        private void AddRoomPriceClick(object sender, RoutedEventArgs e)
        {
            InputBoxRoomPriceAdd.Visibility = Visibility.Visible;
        }

        private void ButtonAddRoomPriceClick(object sender, RoutedEventArgs e)
        {
            InputBoxRoomPriceAdd.Visibility = Visibility.Collapsed;
        }

        private void AddServicePriceClick(object sender, RoutedEventArgs e)
        {
            InputBoxServicePriceAdd.Visibility = Visibility.Visible;
        }

        private void ButtonAddServicePriceClick(object sender, RoutedEventArgs e)
        {
            InputBoxServicePriceAdd.Visibility = Visibility.Collapsed;
        }


        //features for rooms
        private void ButtonFeaturesToRoomClick(object sender, RoutedEventArgs e)
        {
            InputBoxRoomFeatures.Visibility = Visibility.Collapsed;
        }

        private void ButtonDeleteFeaturesFromRoomClick(object sender, RoutedEventArgs e)
        {
            InputBoxDeleteRoomFeatures.Visibility = Visibility.Collapsed;
        }

        private void AddFeaturesForRoomClick(object sender, RoutedEventArgs e)
        {
            InputBoxRoomFeatures.Visibility = Visibility.Visible;
        }


        private void DeleteFeaturesForRoomClick(object sender, RoutedEventArgs e)
        {
            InputBoxDeleteRoomFeatures.Visibility = Visibility.Visible;
        }
    }
}
