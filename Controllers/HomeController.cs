using Bowlers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bowlers.Controllers
{
    public class HomeController : Controller
    {

        private BowlingDbContext _context { get; set; }

        //constructor
        public HomeController(BowlingDbContext temp)
        {
            _context = temp;
        }



        public IActionResult Index()
        {
            var bowlers = _context.Bowlers
                .ToList();

            return View(bowlers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
