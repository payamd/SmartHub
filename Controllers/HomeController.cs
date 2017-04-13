using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHub.Models;

namespace SmartHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var UpCommingGigs=_context.Gigs
                .Include(g => g.Artist)
                .Where(t => t.DateTime > DateTime.Now);
            return View(UpCommingGigs);
        }
  
    }
}