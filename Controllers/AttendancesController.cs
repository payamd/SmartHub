﻿using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using SmartHub.Dtos;
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
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();
            var exist = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);
            if (exist)
            {
                return BadRequest("the gig is already selected");
            }

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
