﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;

namespace BusyRoom.Models
{
    public interface IBusyRoomRepository
    {
        IEnumerable<Room> GetAllRooms();
        IEnumerable<Room> GetAllRoomsWithOcupyStates();
        void AddRoom(Room newRoom);
        bool SaveAll();
    }

    public class BusyRoomRepository : IBusyRoomRepository
    {
        private readonly BusyRoomContext _dbContext;

        public BusyRoomRepository(BusyRoomContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _dbContext.Rooms.OrderBy(r => r.Name).ToList();
        }

        public IEnumerable<Room> GetAllRoomsWithOcupyStates()
        {
            return _dbContext.Rooms.Include(r => r.OccupyStates).OrderBy(r => r.Name).ToList();
        }

        public void AddRoom(Room newRoom)
        {
            _dbContext.Add(newRoom);
        }

        public bool SaveAll()
        {
            return _dbContext.SaveChanges() > 0;
        }
    }
}