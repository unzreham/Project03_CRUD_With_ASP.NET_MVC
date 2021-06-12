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
    public class BookingsController : ControllerBase
    {

        private readonly AppDbContext _db;

        public BookingsController(AppDbContext db)
        {
            _db = db;
        }


        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        {
           return await _db.Bookings.ToListAsync();
             //  return await _db.Bookings.Where(t => t.TourId == id).ToListAsync();
        }


        

        [HttpPost]
        public async Task<ActionResult<Booking>> Create([FromBody] Booking booking)
        {
            Booking b = new Booking();
            b.adult = booking.adult;
            b.child = booking.child;
            int adultNum = Convert.ToInt32(booking.adult);
            int childNum= Convert.ToInt32(booking.child);
            var specificTour = await _db.Tours.FindAsync(booking.TourId);

            int adultPrice = Convert.ToInt32(specificTour.AdultPrice);
            int childPrice = Convert.ToInt32(specificTour.ChildPrice);

            b.total = (adultNum * adultPrice + childNum * childPrice);
         //   b.total = booking.total;
            b.firstName = booking.firstName;
            b.LastName = booking.LastName;
            b.TourId = booking.TourId;

            await this._db.Bookings.AddAsync(b);
            await this._db.SaveChangesAsync();
            return Ok(b);

        }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult<Booking>> Delete([FromRoute] int id)
            {
                Booking b = await this._db.Bookings.FirstOrDefaultAsync(t => t.id == id);
                if (b == null)
                    return NotFound();
                this._db.Bookings.Remove(b);
                await this._db.SaveChangesAsync();
                return Ok(b);
            }


            /*
              int id 
             int adult 
             int child 
             int total 
             string firstName 
             string LastName
             int TourId 
             Tour Tour 
             
             */
        


    }
}
