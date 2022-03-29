using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlerRepository repo { get; set; }

        public HomeController (IBowlerRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string teamName)
        {
            ViewBag.TeamName = teamName;

            var blah = repo.Bowlers
                .Include("Teams")
                .Where(x => x.Teams.TeamName == teamName || teamName == null)
                .ToList();

            return View(blah);
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                repo.SaveBowler(b);
            }

            return View("Confirmation", b);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bowler = repo.Bowlers.Single(x => x.BowlerID == id);

            return View("AddBowler", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            repo.UpdateBowler(b);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = repo.Bowlers.Single(x => x.BowlerID == id);
            return View(bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            repo.DeleteBowler(b);

            return RedirectToAction("Index");
        }

    }
}
