﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SWD_GUI_Assignment.Models;

namespace WebApplication1.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Database.Delete();
        }

        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Lokation> Lokations { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}