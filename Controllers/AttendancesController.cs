using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SmartHub.Models;

namespace SmartHub.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody] int gigId)
        {
            var UserId = User.Identity.GetUserId();

            var exist = _context.Attendances.Any(a => a.AttendeeId == UserId && a.GigId == gigId);
            if (exist)
            {
                return BadRequest("the gig is already selected");
            }

            var attendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = UserId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
