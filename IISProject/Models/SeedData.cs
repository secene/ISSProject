using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IISProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IISProject.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Opel",
                        ModificationData = DateTime.Now,
                        Quantity = 12,
                        Price = 120M
                    },
                    new Product
                    {
                        Name = "BMW",
                        ModificationData = DateTime.Now,
                        Quantity = 4,
                        Price = 230M
                    },
                    new Product
                    {
                        Name = "Audi",
                        ModificationData = DateTime.Now,
                        Quantity = 32,
                        Price = 170M
                    },
                    new Product
                    {
                        Name = "Mercedes",
                        ModificationData = DateTime.Now,
                        Quantity = 27,
                        Price = 130M
                    }

                );
                context.SaveChanges();
            }

        }
    }
}
