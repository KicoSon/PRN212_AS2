﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRoomRepository
    {
        List<RoomInformation> GetAllRooms();
        RoomInformation GetRoomById(int id);
        void AddRoom(RoomInformation room);
        void UpdateRoom(RoomInformation room);
        void DeleteRoom(RoomInformation room);
    }
}
