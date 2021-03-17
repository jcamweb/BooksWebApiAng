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
            //bool created = await context.Database.EnsureCreatedAsync();
            //string creationinfo = created ? "created" : "exists";
            //if (created)
            //{
            //    var b1 = new Book { Titulo = "Contact", Autor = "Carl Sagan", Editorial = "Nasa" };
            //    var b2 = new Book { Titulo = "Título2", Autor = "Autor2", Editorial = "Editorial2" };
            //    var b3 = new Book { Titulo = "Título3", Autor = "Autor3", Editorial = "Editorial3" };
            //    var b4 = new Book { Titulo = "Título4", Autor = "Autor4", Editorial = "Editorial4" };
            //    await context.Books.AddRangeAsync(b1, b2, b3, b4);
            //    int records = await context.SaveChangesAsync();
            //}
            // To Add Data from Seed
            //if (!await context.Books.AnyAsync())
            //{
            //    await context.AddAsync(new Book { });
            //    await context.SaveChangesAsync();
            //}
        }

       
    }
}
