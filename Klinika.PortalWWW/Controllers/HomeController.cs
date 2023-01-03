using Klinika.Data.Data;
using Klinika.Data.Data.CMS;
using Klinika.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Klinika.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KlinikaContext _context;

        public HomeController(KlinikaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ModelOpeningHours =
                (
                from OpeningHours in _context.OpeningHours
                where OpeningHours.CzyAktywny == true
                orderby OpeningHours.PozycjaWyswietlania
                select OpeningHours
                ).ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewBag.ModelOpeningHours =
                (
                from OpeningHours in _context.OpeningHours
                where OpeningHours.CzyAktywny == true
                orderby OpeningHours.PozycjaWyswietlania
                select OpeningHours
                ).ToList();
            return View();
        }
        public IActionResult Service()
        {
            ViewBag.ModelOpeningHours =
                (
                from OpeningHours in _context.OpeningHours
                where OpeningHours.CzyAktywny == true
                orderby OpeningHours.PozycjaWyswietlania
                select OpeningHours
                ).ToList();
            return View();
        }
        public IActionResult Doctor()
        {
            ViewBag.ModelOpeningHours =
                (
                from OpeningHours in _context.OpeningHours
                where OpeningHours.CzyAktywny == true
                orderby OpeningHours.PozycjaWyswietlania
                select OpeningHours
                ).ToList();
            return View();
        }
        public IActionResult Procedure()
        {
            ViewBag.ModelOpeningHours =
                (
                from OpeningHours in _context.OpeningHours
                where OpeningHours.CzyAktywny == true
                orderby OpeningHours.PozycjaWyswietlania
                select OpeningHours
                ).ToList();
            return View();
        }

        public IActionResult Contact()
        {

            ViewBag.ModelOpeningHours =
                (
                from OpeningHours in _context.OpeningHours
                where OpeningHours.CzyAktywny == true
                orderby OpeningHours.PozycjaWyswietlania
                select OpeningHours
                ).ToList();
            return View();
        }

        public IActionResult Departament()
        {
            ViewBag.ModelOpeningHours =
                (
                from OpeningHours in _context.OpeningHours
                where OpeningHours.CzyAktywny == true
                orderby OpeningHours.PozycjaWyswietlania
                select OpeningHours
                ).ToList();
            return View();
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