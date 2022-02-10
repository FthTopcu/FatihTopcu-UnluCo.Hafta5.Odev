using Microsoft.EntityFrameworkCore;
using UnluCo.Hafta2.Odev.Entities;

namespace UnluCo.Hafta2.Odev.DBOperations
{
    public interface ISchoolDbContext
    {
        DbSet<School> Schools { get; set; }
        DbSet<Student> Students { get; set; }

        int SaveChanges();
    }
}
