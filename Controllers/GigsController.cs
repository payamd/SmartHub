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
            var _artist = User.Identity.GetUserId();
            var artist = _context.Users.Single(u => u.Id == _artist);
            var genre = _context.Genres.Single(g => g.Id == ViewModel.Genre);
            var gig = new Gig
            {
                Artist = artist,
                DateTime = DateTime.Parse(string.Format("{0} {1}",ViewModel.Date ,ViewModel.Time )),
                Genre = genre,
                Venue = ViewModel.Venue
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
    }
}