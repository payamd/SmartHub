using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartHub.Models;

namespace SmartHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [ValidTime]
        [Required]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public DateTime GetDateTime() {
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));   
        }
    }
}