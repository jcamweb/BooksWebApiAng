using BooksWebApiAng.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BooksWebApiAng
{
    public class SeedData
    {

        public static async Task InitializeAsync(
           IServiceProvider services)
        {
            var context = services.GetRequiredService<BookContext>();
           await context.Database.MigrateAsync();
            // To Add Data from Seed
            //if (!await context.Books.AnyAsync())
            //{
            //    await context.AddAsync(new Book { });
            //    await context.SaveChangesAsync();
            //}
        }

    }
}
