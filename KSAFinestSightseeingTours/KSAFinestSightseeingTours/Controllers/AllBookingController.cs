using KSA_s_Finest_Sightseeing_Tours.Data;
using KSA_s_Finest_Sightseeing_Tours.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSAFinestSightseeingTours.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AllBookingController : ControllerBase
    {

        private readonly AppDbContext _db;

        public AllBookingController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking([FromRoute] int id)
        {
           // return await _db.Bookings.ToListAsync();
             return await _db.Bookings.Where(t => t.TourId == id).ToListAsync();
        }




    
    }





}
