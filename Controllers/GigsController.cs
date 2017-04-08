using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHub.Models;
using SmartHub.ViewModels;

namespace SmartHub.Controllers
{
    public class GigsController : Controller
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            _context=new ApplicationDbContext();
        }

        // GET: Gigs
        public ActionResult Create()
        {
            var ViewModel = new GigFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
           
            return View(ViewModel);
        }
    }
}