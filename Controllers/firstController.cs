using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TASK2.Models;

namespace TASK2.Controllers
{
    public class firstController : Controller
    {
        private RMSContext R = null;
        public firstController(RMSContext _R)
        {
            R = _R;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddNewAirline()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAirline(Airline A)
        {
            try
            {
                R.Airline.AddAsync(A);
                R.SaveChangesAsync();
                ViewBag.Message = A.Name + " Airline saved Successfully!";
                ViewBag.MessageType = "S";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error in saving the data, please try again.";
                ViewBag.MessageType = "E";


            }



            return View();
        }
        public IActionResult AllAirlines()
        {
            return View(R.Airline.ToList());
        }

        public IActionResult DeleteAirline(int id)
        {
            var A = R.Airline.Find(id);
            R.Airline.Remove(A);
            R.SaveChanges();

            return RedirectToAction("AllAirlines");
        }


        [HttpGet]
        public IActionResult EditAirline(int id)
        {
            var A = R.Airline.Find(id);
            return View(A);
        }

        [HttpPost]
        public IActionResult EditAirline(Airline A)
        {
            R.Airline.Update(A);
            R.SaveChanges();
            return RedirectToAction("AllAirlines");
        }
        public IActionResult ViewAirlineDetail(int id)
        {
            return View(R.Airline.Find(id));
        }

    }

}
  