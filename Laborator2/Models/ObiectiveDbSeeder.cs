using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laborator2.Models
{
    public class ObiectiveDbSeeder
    {
        public static void Initialize(ObiectiveDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any tasks.
            if (context.Obiective.Any())
            {
                return;   // DB has been seeded
            }

            context.Obiective.AddRange(
                new Obiectiv
                {
                    Title = "Lab1",
                    Description = "Task_request"
                },
                  new Obiectiv
                  {
                      Title = "Lab2",
                      Description = "Movie_request"
                  }
            );
            context.SaveChanges();
        }



    }
}
