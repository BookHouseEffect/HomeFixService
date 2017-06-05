﻿using HomeFixService.WebService.Models.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HomeFixService.WebService.Models.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<UserAddresses> UserAddresses { get; set; }
        public DbSet<UserProfessions> UserProfessions { get; set; }
        public DbSet<ProfessionServices> ProfessionServices { get; set; }
        public DbSet<TimeSchedules> TimeSchedules { get; set; }
        public DbSet<BusySchedules> BusySchedules { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<UserPasswordsHistory> UserPasswordsHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

 }