﻿using System;
using System.Collections.Generic;
using System.Text;
using ClaytonsOpinion.Data.BizModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClaytonsOpinion.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Entree> Entrees { get; set; }
        public DbSet<EntreeReview> EntreeReviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
