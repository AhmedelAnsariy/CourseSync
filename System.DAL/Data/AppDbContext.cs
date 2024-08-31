using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.DAL.Models;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.DAL.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);


            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "default-user-id",
                    UserName = "ahmedansary@gmail.com",
                    NormalizedUserName = "AHMEDANSARY@GMAIL.COM",
                    Email = "ahmedansary@gmail.com",
                    NormalizedEmail = "AHMEDANSARY@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Ahmed@123"),
                    SecurityStamp = string.Empty,
                    FName = "Ahmed",
                    LName = "Ansary"
                }
            );
        

    }

        public DbSet<Student> Students { get; set; }
        public DbSet<GroupName> GroupNames { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Installment> Installments { get; set; }



    }
}
