using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication7.Data;
using WebApplication7.Data.Models;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
  
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext db;

    
        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

       public JsonResult GetAllAppointment()
        {


            return new JsonResult(this.db.Events.ToList());
        }

        [HttpPost]
        public IActionResult AddEvent([FromBody] Event app)
        {
            this.db.Events.Add(app);
            db.SaveChanges();

            return new JsonResult("Success");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
