using System;
using CS321_W3D1_ToDoAPI_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D1_ToDoAPI_EF.Data
{
    public class ToDoContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // tell DbContext that we are using Sqlite, and give it a connection string
            optionsBuilder.UseSqlite("Data Source=blogging.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // not required, but helpful to set up some initial data
            modelBuilder.Entity<ToDo>().HasData(
               new ToDo { Id = 1, Description = "Laundry" },
               new ToDo { Id = 2, Description = "Shopping" },
               new ToDo { Id = 3, Description = "Mow lawn" }
            );
        }

        public DbSet<ToDo> ToDos { get; set; }

    }


}
