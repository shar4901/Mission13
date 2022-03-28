using Microsoft.AspNetCore.Mvc;
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

        private IBowlersRepository _repo  { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int? teamId = null)
        {
            List<Team> teams = _repo.Teams.ToList();
            ViewBag.team = teams;

            if (teamId == null)
            {
                List<Bowler> bowlers = _repo.Bowlers
                    .OrderBy(x => x.TeamId)
                    .ToList();
                ViewBag.bowlers = bowlers;
            }
            else
            {
                List<Bowler> bowlers = _repo.Bowlers
                    .Where(x => x.TeamId == teamId)
                    .ToList();
                ViewBag.bowlers = bowlers;
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult AddBowler(int bowlerId = 0)
        {
            List<Team> teams = _repo.Teams.ToList();
            ViewBag.team = teams;

            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _repo.EditBowler(bowler);
                _repo.SaveBowler(bowler);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerId)
        {
            _repo.DeleteBowler(bowlerId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit (int bowlerId)
        {
            Bowler bowler = _repo.Bowlers.Where(x => x.BowlerId == bowlerId).FirstOrDefault();

            List<Team> teams = _repo.Teams.ToList();
            ViewBag.team = teams;

            return View("AddBowler", bowler);
        }
        public IActionResult TeamList()
        {
            List<Team> teams = _repo.Teams
                .ToList();

            return View(teams);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
