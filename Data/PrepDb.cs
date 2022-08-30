using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonService.Models;

namespace PersonService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }
            
            if(!context.Persons.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Persons.AddRange(
                    new Person() {Name="slimani", Lastname="reda", Mail="reda@yahoo.fr"},
                    new Person() {Name="mahmoud", Lastname = "youcef", Mail = "youcef@yahoo.fr" },
                    new Person() {Name="belaid", Lastname = "samir", Mail = "samir@yahoo.fr" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}