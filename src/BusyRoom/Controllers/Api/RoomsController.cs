using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusyRoom.Models;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BusyRoom.Controllers.Api
{
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private IBusyRoomRepository _repository;

        public RoomsController(IBusyRoomRepository repository)
        {
            _repository = repository;
        }

        // GET: api/rooms
        [HttpGet]
        public JsonResult Get()
        {
            var rooms = _repository.GetAllRoomsWithOcupyStates();
            var json = Json(rooms);
            return json;
        }
    }
}
