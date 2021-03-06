﻿using System;
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
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IBusyRoomRepository _repository;
        private readonly ILogger<RoomsController> _logger;

        public RoomsController(IBusyRoomRepository repository, ILogger<RoomsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/rooms
        [HttpGet]
        public JsonResult Get()
        {
            var results = Mapper.Map<IEnumerable<RoomViewModel>>(_repository.GetAllRoomsWithStates());
            return Json(results);
        }

        [HttpPost]
        public JsonResult Post([FromBody] RoomViewModel roomViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newRoom = Mapper.Map<Room>(roomViewModel);

                    // Save to the database
                    _logger.LogInformation("Attempting to save a new room");
                    _repository.AddRoom(newRoom);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int) HttpStatusCode.Created;
                        return Json(Mapper.Map<RoomViewModel>(newRoom));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to save new room", ex);
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(new {Message = ex.Message});
            }
            Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return Json(new {Message = "Failed", ModelState = ModelState});
        }
    }
}