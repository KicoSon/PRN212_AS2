using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DataAccess.DAO;
using DataAccess.Models;
using DataAccess.Repository;
namespace SonPTWPF
{
    public partial class RoomInfoWindow : Window
    {
        private readonly RoomRepository _roomRepository;
        private readonly FuminiHotelManagementContext _context;
        public List<RoomInformation> Rooms { get; set; }
        public RoomInformation SelectedRoom { get; set; }

        public RoomInfoWindow()
        {
            InitializeComponent();
            _context = new FuminiHotelManagementContext();
            _roomRepository = new RoomRepository(new RoomDAO(_context));
            RefreshRoomData();
        }

        private void RefreshRoomData()
        {
            Rooms = _roomRepository.GetAllRooms().ToList();
            dgRooms.ItemsSource = Rooms;
        }

        private void btnCreateRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomInformation newRoom = new RoomInformation
            {
                RoomNumber = txtRoomNumber.Text,
                RoomDetailDescription = txtRoomDescription.Text,
                RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text),
                RoomTypeId = int.Parse(txtRoomTypeID.Text),
                RoomStatus = byte.Parse(txtRoomStatus.Text),
                RoomPricePerDay = decimal.Parse(txtRoomPricePerDay.Text)
            };

            _roomRepository.AddRoom(newRoom);
            RefreshRoomData();
            ClearInputs();
        }

        private void btnUpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRoom != null)
            {
                SelectedRoom.RoomNumber = txtRoomNumber.Text;
                SelectedRoom.RoomDetailDescription = txtRoomDescription.Text;
                SelectedRoom.RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text);
                SelectedRoom.RoomTypeId = int.Parse(txtRoomTypeID.Text);
                SelectedRoom.RoomStatus = byte.Parse(txtRoomStatus.Text);
                SelectedRoom.RoomPricePerDay = decimal.Parse(txtRoomPricePerDay.Text);

                _roomRepository.UpdateRoom(SelectedRoom);
                RefreshRoomData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a room to update.");
            }
        }

        private void btnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedRoom != null)
            {
                _roomRepository.DeleteRoom(SelectedRoom);
                RefreshRoomData();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Please select a room to delete.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearInputs()
        {
            txtRoomID.Text = "";
            txtRoomNumber.Text = "";
            txtRoomDescription.Text = "";
            txtRoomMaxCapacity.Text = "";
            txtRoomTypeID.Text = "";
            txtRoomStatus.Text = "";
            txtRoomPricePerDay.Text = "";
        }

        private void dgRoomData_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SelectedRoom = dgRooms.SelectedItem as RoomInformation;
            if (SelectedRoom != null)
            {
                txtRoomID.Text = SelectedRoom.RoomId.ToString();
                txtRoomNumber.Text = SelectedRoom.RoomNumber;
                txtRoomDescription.Text = SelectedRoom.RoomDetailDescription;
                txtRoomMaxCapacity.Text = SelectedRoom.RoomMaxCapacity.ToString();
                txtRoomTypeID.Text = SelectedRoom.RoomTypeId.ToString();
                txtRoomStatus.Text = SelectedRoom.RoomStatus.ToString();
                txtRoomPricePerDay.Text = SelectedRoom.RoomPricePerDay.ToString();
            }
        }
    }
}