using Microsoft.AspNetCore.Mvc;
using nartyy.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using EntityState = System.Data.Entity.EntityState;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using nartyy.Migrations;

namespace nartyy.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db = new ApplicationDbContext();

        private Rezerwacja rezerwacja;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            rezerwacja = new Rezerwacja();

        }


        public IActionResult Index()
        {

            return View();

        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            ViewData["Layout"] = "_Layout";
            return View();
        }

        [Route("LogOn")]
        public IActionResult LogOn()
        {
            ViewData["Layout"] = "_Layout";
            return View();
        }

        [Route("Cash")]
        public IActionResult Cash()
        {
            ViewData["Layout"] = "_Layout";
            return View();
        }

        [Route("Company")]
        public IActionResult Company()
        {
            ViewData["Layout"] = "_Layout";
            return View();
        }

        [Route("Rezerwacja")]

        [HttpPost]


        public IActionResult Rezerwacja(int id, string? typSprzetu, DateTime? dataRezerwacji, DateTime? dataZwrotu, string? user)
        {

            if (typSprzetu == "narty")
            {
                var narty = db.Narty.Find(id);
                if (narty.Dostepnosc == false)
                {

                    return View("~/Views/Login/Loginnn");
                }
                else
                {
                    narty.Dostepnosc = false;
                    db.Entry(narty).State = EntityState.Modified;

                    var usserr = db.Clients.FirstOrDefault(e => e.Username == user);
                    rezerwacja.IDSprzet = id;
                    rezerwacja.TypSprzetu = "narty";
                    rezerwacja.DataOdbioru = dataRezerwacji;
                    rezerwacja.DataZwrotu = dataZwrotu;
                    rezerwacja.IDClient = usserr.IDClient;
                    db.Rezerwacje.Add(rezerwacja);
                    narty.IDRezerwacji = rezerwacja.IDSprzet;
                    db.SaveChanges();
                    Thread.Sleep(1000);
                    ViewBag.SuccessMessage = "Rezerwacja nart zakończona pomyślnie.";


                    ViewBag.Narty = db.Narty.ToList();
                    ViewBag.Buty = db.ButyNarciarskiee.ToList();
                    ViewBag.Client = db.Clients.ToList();
                    ViewBag.Rezerw = db.Rezerwacje.ToList();


                    return RedirectToAction("Loginnn", "Login");
                }
            }
            else if (typSprzetu == "buty")
            {
                var buty = db.ButyNarciarskiee.Find(id);
                if (buty.Dostepnosc == false)
                {
                    return RedirectToAction("Loginnn", "Login");
                }
                else
                {
                    buty.Dostepnosc = false;
                    db.Entry(buty).State = EntityState.Modified;

                    var usserr = db.Clients.FirstOrDefault(e => e.Username == user);
                    rezerwacja.IDSprzet = id;
                    rezerwacja.TypSprzetu = "buty";
                    rezerwacja.DataOdbioru = dataRezerwacji;
                    rezerwacja.DataZwrotu = dataZwrotu;
                    rezerwacja.IDClient = usserr.IDClient;
                    db.Rezerwacje.Add(rezerwacja);
                    buty.IDRezerwacji = rezerwacja.IDSprzet;
                    db.SaveChanges();
                    Thread.Sleep(1000);
                    ViewBag.SuccessMessage = "Rezerwacja butow zakończona pomyślnie.";
                    ViewBag.Narty = db.Narty.ToList();
                    ViewBag.Buty = db.ButyNarciarskiee.ToList();
                    ViewBag.Client = db.Clients.ToList();
                    ViewBag.Rezerw = db.Rezerwacje.ToList();

                    return RedirectToAction("Loginnn", "Login");
                }
            }

            else
            {
                ViewBag.ErrorMessage = "Nieznany typ sprzętu.";
                return RedirectToAction("Index");
            }


        }

        [Route("Resign")]
        [Authorize]
        [HttpPost]
        public IActionResult Resign(int id)
        {
            try
            {
                var entity_Remove = db.Rezerwacje.FirstOrDefault(e => e.IDSprzet == id);
                var narty_remove = db.Narty.FirstOrDefault(e => e.IDRezerwacji == entity_Remove.IDSprzet);
                var buty_remove = db.ButyNarciarskiee.FirstOrDefault(e => e.IDRezerwacji == entity_Remove.IDSprzet);
                if (narty_remove != null)
                {
                    narty_remove.Dostepnosc = true;
                    narty_remove.IDRezerwacji = null;
                }
                if (buty_remove != null)
                {
                    buty_remove.Dostepnosc = true;
                    buty_remove.IDRezerwacji = null;
                }
                if (entity_Remove != null)
                { db.Rezerwacje.Remove(entity_Remove); }

                db.SaveChanges();
                Thread.Sleep(1000);
            }
            catch { RedirectToAction("Loginnn", "Login"); }
            ViewBag.Narty = db.Narty.ToList();
            ViewBag.Buty = db.ButyNarciarskiee.ToList();
            ViewBag.Client = db.Clients.ToList();
            ViewBag.Rezerw = db.Rezerwacje.ToList();

            return RedirectToAction("Loginnn", "Login");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}