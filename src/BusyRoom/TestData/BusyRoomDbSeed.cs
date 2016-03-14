using System;
using System.Collections.Generic;
using System.Linq;
using BusyRoom.Models;

namespace BusyRoom.TestData
{
    public class BusyRoomDbSeed
    {
        private readonly BusyRoomContext _dbContext;

        public BusyRoomDbSeed(BusyRoomContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void EnsureSeedData()
        {
            // Ensure the database exists
            _dbContext.Database.EnsureCreated();

            if (!_dbContext.Rooms.Any())
            {
                // Add new data
                var arduino = new Room
                {
                    Name = "Arduino",
                    CreatedOn = DateTime.UtcNow.AddDays(-4),
                    States = new List<State>
                    {
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-6),
                            IsOccupied = true
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-5),
                            IsOccupied = false
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-4),
                            IsOccupied = false
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-3),
                            IsOccupied = true
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-2),
                            IsOccupied = false
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-1),
                            IsOccupied = true
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow,
                            IsOccupied = true
                        },
                    }
                };

                _dbContext.Rooms.Add(arduino);
                _dbContext.AddRange();

                _dbContext.SaveChanges();
            }
        }
    }
}