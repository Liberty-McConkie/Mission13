using Microsoft.AspNetCore.Mvc;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlerRepository repo { get; set; }

        public TeamsViewComponent (IBowlerRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];

            var teams = repo.Bowlers.Select(x => x.Teams.TeamName).Distinct().OrderBy(x => x);

            return View(teams);
        }
    }
}
