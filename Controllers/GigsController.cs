using System.Linq;
using System.Web.Mvc;
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

        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
           
            return View(viewModel);
        }
    }
}