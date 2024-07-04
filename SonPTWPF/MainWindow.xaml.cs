using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SonPTWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCustomerInfo_Click(object sender, RoutedEventArgs e)
        {
            CustomerInfoWindow Window = new CustomerInfoWindow();
            Window.ShowDialog();
        }

        private void btnRoomInfo_Click(object sender, RoutedEventArgs e)
        {
            RoomInfoWindow Window = new RoomInfoWindow();
            Window.ShowDialog();
        }

        private void btnBookingInfo_Click(object sender, RoutedEventArgs e)
        {
            BookingInfoWindow Window = new BookingInfoWindow();
            Window.ShowDialog();
        }
    }
}