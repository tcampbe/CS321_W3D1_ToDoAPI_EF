using System;
using CS321_W3D1_ToDoAPI_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CS321_W3D1_ToDoAPI_EF.Data
{
    public class ToDoContext : DbContext
    {
        // This DbSet<ToDo> represents our ToDo table in the db
        public DbSet<ToDo> ToDos { get; set; }

        // This method runs once when the DbContext is first used.
        // It configures our ToDos.db file with EF Core.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ToDos.db");
        }

        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // ToDo model to the database. In this case, we're simple telling
        // EF to add some initial items to the ToDo table. This will only
        // happen once when the db is first created.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDo>().HasData(
            new ToDo { Id = 1, Description = "Laundry" },
            new ToDo { Id = 2, Description = "Shopping" },
            new ToDo { Id = 3, Description = "Mow lawn" }
            );
        }
    }
}