using KSA_s_Finest_Sightseeing_Tours.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KSA_s_Finest_Sightseeing_Tours.Models;

namespace KSAFinestSightseeingTours.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController  : ControllerBase
    {

        private readonly AppDbContext _db;

        public ToursController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/Tours
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tour>>> AllToura()
        {
            return await _db.Tours.ToListAsync();


        //    return await _db.Tours.Where(t => t.TourId == id).ToListAsync();

        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Tour>> GetOne([FromRoute] int id)
        {

            var tour = await _db.Tours.Include(i => i.Included).FirstOrDefaultAsync(t => t.TourId == id);
         //   IQueryable<Tour> tours = _db.Tours.Where(t => t.TourId == id);
           

            if (tour == null)
            {
                return NotFound();
            }

            return tour;
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Tour>> Delete([FromRoute] int id)
        {
            Tour tour = await this._db.Tours.FirstOrDefaultAsync(t => t.TourId == id);
            if (tour == null)
                return NotFound();
            this._db.Tours.Remove(tour);
            await this._db.SaveChangesAsync();
            return Ok(tour);
        }





        /*
                [HttpPost]
                public async Task<ActionResult<User>> Create([FromBody] User user)
                {
                    await this._db.Users.AddAsync(user);
                    await this._db.SaveChangesAsync();
                    return Ok(user);
                }*/

        [HttpPost]
        public async Task<ActionResult<Tour>> Create([FromBody] Tour tour)
        {
            await this._db.Tours.AddAsync(tour);
            await this._db.SaveChangesAsync();
            return Ok(tour);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Tour>> Update([FromRoute] int id, [FromBody] Tour tour)
        {
            Tour obj = await this._db.Tours.FirstOrDefaultAsync(tour => tour.TourId == id);

            if (tour == null)
                return NotFound();
            obj.Place = tour.Place;
            obj.Description = tour.Description;
            obj.AdultPrice = tour.AdultPrice;
            obj.ChildPrice = tour.ChildPrice;
            obj.PickupLocation = tour.PickupLocation;
            obj.ReturnsAt = tour.ReturnsAt;
            obj.DepartsAt = tour.DepartsAt;
            obj.Image = tour.Image;
            obj.Included = tour.Included;
            this._db.Tours.Update(obj);
            await this._db.SaveChangesAsync();
            return Ok(obj);


            /*
             
              int TourId
                             string Place 
                             string Description 
                             string AdultPrice 
                             string ChildPrice 
                             string PickupLocation 
                             DateTime ReturnsAt 
                             DateTime DepartsAt 
                             string Image
                             Included Included 
             
             */
        }


    }
}
