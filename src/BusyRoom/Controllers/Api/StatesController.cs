using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using BusyRoom.Models;
using BusyRoom.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BusyRoom.Controllers.Api
{
    [Route("api/rooms/{roomName}/[controller]")]
    public class StatesController : Controller
    {
        private readonly ILogger<StatesController> _logger;
        private readonly IBusyRoomRepository _repository;

        public StatesController(IBusyRoomRepository repository, ILogger<StatesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult Get(string roomName)
        {
            try
            {
                var room = _repository.GetRoom(roomName);

                if (room == null)
                {
                    return Json(null);
                }

                return Json(Mapper.Map<IEnumerable<StateViewModel>>(room.States.OrderBy(s => s.CreatedOn)));
            }
            catch (Exception ex)
            {
                var message = $"Error occurred while getting states for room {roomName}";
                _logger.LogError(message, ex);
                Response.StatusCode = (int) HttpStatusCode.BadRequest;

                return Json(message);
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}