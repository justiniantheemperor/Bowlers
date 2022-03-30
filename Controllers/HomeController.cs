using Bowlers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private IBowlingRepository _repo { get; set; }

        //constructor
        public HomeController(IBowlingRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BowlerHome()
        {
            var bowlers = _repo.Bowlers
                .Include(x => x.Team)
                .ToList();

            return View(bowlers);
        }

        // View Teams page
        public IActionResult Teams()
        {
            var teams = _repo.Teams
                .ToList();

            return View(teams);
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
