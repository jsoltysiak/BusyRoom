using System.Linq;
using BusyRoom.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace BusyRoom.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusyRoomRepository _repository;

        public HomeController(BusyRoomContext dbContext, IBusyRoomRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var rooms = _repository.GetAllRoomsWithStates();
            return View(rooms);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}