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

        public IActionResult Index()
        {
            List<Bowler> bowlers = _repo.Bowlers
                .OrderBy(x => x.TeamId)
                .ToList();
            return View(bowlers);
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
