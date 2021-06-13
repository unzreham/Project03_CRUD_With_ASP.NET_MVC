using KSA_s_Finest_Sightseeing_Tours.Data;
using KSA_s_Finest_Sightseeing_Tours.Models;
using Microsoft.AspNetCore.Http;
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
    public class UsersController : ControllerBase
    {

        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _db.Users.ToListAsync();


            //    return await _db.Tours.Where(t => t.TourId == id).ToListAsync();

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _db.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }




        [HttpPost]
        public async Task<IActionResult> FindEmail(User user)
        {
            User u = await this._db.Users.FirstOrDefaultAsync(usr => usr.email == user.email);
            if (u == null)
            {
                NotFound();
            }
            else
            {

                if(u.password == user.password)
                {
                    return Ok(u);
                }
               
            }
            return BadRequest();

        }





    }
}
