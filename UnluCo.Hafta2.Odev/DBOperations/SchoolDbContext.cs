using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UnluCo.Hafta2.Odev.Entities;

namespace UnluCo.Hafta2.Odev.DBOperations
{
    public class SchoolDbContext : DbContext , ISchoolDbContext 
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        { }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public static List<User> userlist = new List<User>
        {
            new User
            {
                Username = "dnm",
                Password="dnm"
            }
        };
    }
}
