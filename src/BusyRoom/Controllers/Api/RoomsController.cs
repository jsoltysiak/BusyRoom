using System.Linq;
using System.Net;
using BusyRoom.Models;
using BusyRoom.ViewModels;
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

        [HttpPost]
        public JsonResult Post([FromBody] RoomViewModel room)
        {
            if (ModelState.IsValid)
            {
                Response.StatusCode = (int) HttpStatusCode.Created;
                return Json(room);
            }

            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return Json(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
        }
    }
}