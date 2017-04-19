using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHub.Models;
using SmartHub.ViewModels;

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
            var upCommingGigs=_context.Gigs
                .Include(g => g.Artist)
                .Include(g=>g.Genre)
                .Where(t => t.DateTime > DateTime.Now);

            var viewModel = new GigsViewModel
            {
                UpCommingGigs = upCommingGigs,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }
  
    }
}