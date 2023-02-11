using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Cosmetic> cosmetics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Guid myuuid = Guid.NewGuid();
            modelBuilder.Entity<Cosmetic>().HasData(new Cosmetic
            {
                image = "https://m.media-amazon.com/images/I/51d3KvJwdAL._SL1000_.jpg",
                name = "Miror",
                id = Guid.NewGuid().ToString(),
                price = 99.99,
                description = "this is miror",
                brand = "GuCci",
            });
            modelBuilder.Entity<Cosmetic>().HasData(new Cosmetic
            {
                image = "https://m.media-amazon.com/images/I/51gD8c5l6GL._SL1500_.jpg",
                name = "Lip Gloss",
                id = Guid.NewGuid().ToString(),
                price = 99.99,
                description = "this is Lip Gloss",
                brand = "GuCci",
            });

            modelBuilder.Entity<Cosmetic>().HasData(new Cosmetic
            {
                image = "https://www.shutterstock.com/image-illustration/blank-eyeliner-mascara-tube-golden-260nw-2145996573.jpg",
                name = "Maskra",
                id = Guid.NewGuid().ToString(),
                price = 99.99,
                description = "this is Maskra",
                brand = "GuCci",
            });


        }
    }
}
