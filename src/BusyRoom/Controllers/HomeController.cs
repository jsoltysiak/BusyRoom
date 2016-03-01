using System.Linq;
using BusyRoom.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace BusyRoom.Controllers
{
    public class HomeController : Controller
    {
        private readonly BusyRoomContext _dbContext;

        public HomeController(BusyRoomContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var rooms = _dbContext.Rooms.Include(n => n.OccupyStates).FirstOrDefault();
            return View(rooms);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}