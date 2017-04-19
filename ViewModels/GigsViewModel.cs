using System.Collections.Generic;
using SmartHub.Models;

namespace SmartHub.ViewModels
{
    public class GigsViewModel
    {
        public IEnumerable<Gig> UpCommingGigs { get; set; }
        public bool ShowActions { get; set; }
    }
}