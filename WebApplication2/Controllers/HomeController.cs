using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using Partyinvites.Models;


namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        

        public  ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guest)
        {
            Repository.AddResponse(guest);
            return View("Thanks",guest);
        }
        public ViewResult ListResponses()
        {
            return View("ListResponses",Repository.Responses.Where(r=>r.WillAttend==true));
        }
    }
}
