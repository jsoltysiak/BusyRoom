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
                            IsOccupied = true,
                            Temperature = 23.5,
                            Humidity = 40,
                            Brightness = 8
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-5),
                            IsOccupied = false,
                            Temperature = 24.5,
                            Humidity = 57,
                            Brightness = 9
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-4),
                            IsOccupied = false,
                            Temperature = 22.0,
                            Humidity = 49,
                            Brightness = 3
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-3),
                            IsOccupied = true,
                            Temperature = 25.5,
                            Humidity = 33,
                            Brightness = 2
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-2),
                            IsOccupied = false,
                            Temperature = 26,
                            Humidity = 35,
                            Brightness = 7
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow.AddMinutes(-1),
                            IsOccupied = true,
                            Temperature = 26.5,
                            Humidity = 43,
                            Brightness = 6
                        },
                        new State
                        {
                            CreatedOn = DateTime.UtcNow,
                            IsOccupied = true,
                            Temperature = 24.0,
                            Humidity = 46,
                            Brightness = 8
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