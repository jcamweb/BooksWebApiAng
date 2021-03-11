using BooksWebApiAng.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksWebApiAng.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Autor = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Editorial = table.Column<string>(type: "nvarchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Titulo", "Autor", "Editorial" },
                values: new object[] { "Contact", "Carl Sagan", "Nasa" });


            migrationBuilder.InsertData(
               table: "Books",
               columns: new[] { "Titulo", "Autor", "Editorial" },
               values: new object[] { "Título1", "Autor1", "Editorial1" });


            migrationBuilder.InsertData(
               table: "Books",
               columns: new[] { "Titulo", "Autor", "Editorial" },
               values: new object[] { "Título2", "Autor2", "Editorial2" });

            migrationBuilder.InsertData(
               table: "Books",
               columns: new[] { "Titulo", "Autor", "Editorial" },
               values: new object[] { "Título3", "Autor3", "Eidtorial3" });




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Book>()
        //        .ToTable("Books");
        //    modelBuilder.Entity<Book>()
        // .Property(s => s.Editorial)
        // .IsRequired(false);

        //    modelBuilder.Entity<Book>()
        //        .HasData(
        //            new Book
        //            {
        //                Titulo = "Contact",
        //                Autor = "Carl Sagan",
        //                Editorial = "Nasa"
        //            },
        //            new Book
        //            {
        //                Titulo = "Título1",
        //                Autor = "Autor1",
        //                Editorial = "Editorial1"
        //            },


        //          new Book
        //         {
        //             Titulo = "Título2",
        //             Autor = "Autor2",
        //             Editorial = "Editorial2"
        //         },

        //           new Book
        //           {
        //               Titulo = "Título3",
        //               Autor = "Autor3",
        //               Editorial = "Editorial3"
        //           }

        //        );
        //}

    }
}
