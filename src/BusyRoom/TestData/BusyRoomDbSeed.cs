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
            _dbContext.Database.EnsureCreated();

            if (!_dbContext.Rooms.Any())
            {
                //Add new data
                var foosball = new Room
                {
                    Name = "Foosball",
                    CreatedOn = DateTime.Now.AddDays(-4).AddSeconds(-8956),
                    States = new List<State>
                    {
                        new State
                        {
                            CreatedOn = DateTime.Now.AddDays(-2),
                            IsOccupied = true
                        },
                        new State
                        {
                            CreatedOn = DateTime.Now.AddHours(-1),
                            IsOccupied = true
                        },
                        new State
                        {
                            CreatedOn = DateTime.Now,
                            IsOccupied = false
                        },
                    }
                };

                _dbContext.Rooms.Add(foosball);
                _dbContext.AddRange();

                var python = new Room
                {
                    Name = "Python",
                    CreatedOn = DateTime.Now,
                    States = new List<State>
                    {
                        new State
                        {
                            CreatedOn = DateTime.Now.AddMinutes(-10),
                            IsOccupied = true
                        },
                        new State
                        {
                            CreatedOn = DateTime.Now.AddMinutes(-1),
                            IsOccupied = false
                        },
                        new State
                        {
                            CreatedOn = DateTime.Now,
                            IsOccupied = true
                        },
                        new State
                        {
                            CreatedOn = DateTime.Now,
                            IsOccupied = false
                        },
                    }
                };

                _dbContext.Rooms.Add(python);
                _dbContext.AddRange(python.States);

                _dbContext.SaveChanges();
            }
        }
    }
}