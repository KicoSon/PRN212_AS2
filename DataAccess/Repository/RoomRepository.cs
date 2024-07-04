using DataAccess.DAO;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly RoomDAO _roomDAO;

        public RoomRepository(RoomDAO roomDAO)
        {
            _roomDAO = roomDAO;
        }
        public List<RoomInformation> GetAllRooms() => RoomDAO.GetRooms();

        public RoomInformation GetRoomById(int id) => RoomDAO.GetRoomById(id);

        public void AddRoom(RoomInformation room) => RoomDAO.SaveRoom(room);

        public void UpdateRoom(RoomInformation room) => RoomDAO.UpdateRoom(room);

        public void DeleteRoom(RoomInformation room) => RoomDAO.DeleteRoom(room);
    }
}
