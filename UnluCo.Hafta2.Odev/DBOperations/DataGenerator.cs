using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnluCo.Hafta2.Odev.Entities;

namespace UnluCo.Hafta2.Odev.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolDbContext(serviceProvider.GetRequiredService<DbContextOptions<SchoolDbContext>>()))
            {
                if (context.Schools.Any())
                    return;

                context.Schools.AddRange(
                    new School
                    { Name = "Ataşehir Anadolu" },
                    new School
                    { Name = "Kayışdağı ArifPaşa" },
                    new School
                    { Name = "Celal Bayar" }
                );
                context.Students.AddRange(
                    new Student { Name = "Fatih", Surname = "Topcu", Email = "fatih@mail.com", SchoolId = 1 },
                    new Student { Name = "Arif", Surname = "Paşa", Email = "arif@mail.com", SchoolId = 2 },
                    new Student { Name = "Celal", Surname = "Bayar", Email = "Celal@mail.com", SchoolId = 3 }
                );

                context.SaveChanges();

            }
        }
    }
}
