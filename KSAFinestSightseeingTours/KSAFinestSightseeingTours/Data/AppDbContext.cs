using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSA_s_Finest_Sightseeing_Tours.Models;

namespace KSA_s_Finest_Sightseeing_Tours.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Tour> Tours { get; set; }
       public DbSet<Included> Includeds { get; set; }

        public DbSet<Booking> Bookings { get; set; }




    }



}

