using Bowlers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class TeamsViewComponent : ViewComponent
    {
        // load up data
        private IBowlingRepository repo { get; set; }

        public TeamsViewComponent(IBowlingRepository temp)
        {
            repo = temp;
        }

        // 
        public IViewComponentResult Invoke()
        {
            var teams = repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }