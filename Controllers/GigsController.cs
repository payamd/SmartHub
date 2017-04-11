using System;
using System.Linq;
using System.Security.AccessControl;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SmartHub.Models;
using SmartHub.ViewModels;

namespace SmartHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context=new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(GigFormViewModel ViewModel)
        {
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                DateTime = ViewModel.DateTime,
                GenreId = ViewModel.Genre,
                Venue = ViewModel.Venue
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
    }
}