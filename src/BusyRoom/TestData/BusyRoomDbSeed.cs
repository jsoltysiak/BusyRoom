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
            if (!_dbContext.Rooms.Any())
            {
                //Add new data
                var foosball = new Room
                {
                    Name = "Foosball",
                    OccupyStates = new List<OccupyState>
                    {
                        new OccupyState
                        {
                            CreatedOn = DateTime.Now.AddDays(-2),
                            IsBusy = true
                        },
                        new OccupyState
                        {
                            CreatedOn = DateTime.Now.AddHours(-1),
                            IsBusy = true
                        },
                        new OccupyState
                        {
                            CreatedOn = DateTime.Now,
                            IsBusy = true
                        },
                    }
                    
                };

                _dbContext.Rooms.Add(foosball);
                _dbContext.AddRange();

                var python = new Room
                {
                    Name = "Python",
                    OccupyStates = new List<OccupyState>
                    {
                        new OccupyState
                        {
                            CreatedOn = DateTime.Now.AddMinutes(-10),
                            IsBusy = true
                        },
                        new OccupyState
                        {
                            CreatedOn = DateTime.Now.AddMinutes(-1),
                            IsBusy = true
                        },
                        new OccupyState
                        {
                            CreatedOn = DateTime.Now,
                            IsBusy = true
                        },
                    }
                };

                _dbContext.Rooms.Add(python);
                _dbContext.AddRange(python.OccupyStates);

                _dbContext.SaveChanges();
            }
        }
    }
}