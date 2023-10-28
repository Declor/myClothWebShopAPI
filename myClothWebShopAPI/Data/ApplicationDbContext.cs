using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using myClothWebShopAPI.Models;

namespace myClothWebShopAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string path;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment webHostEnvironment)
            : base(options)
        {
            _webHostEnvironment = webHostEnvironment;
            path = _webHostEnvironment.ContentRootPath;
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "adminMyShop@gmail.com",
                NormalizedEmail = "ADMINMYSHOP@GMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "adminPassword123")
                
            });


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "1",
                RoleId = "1"
            });

            

            //string getBase64Image(string imagePath)
            //{
            //    byte[] imageBytes = System.IO.File.ReadAllBytes(imagePath); // // Функция System.IO.File.ReadAllBytes читает содержимое файла и возвращает его в виде массива байтов (byte[]).

            //    string base64Image = Convert.ToBase64String(imageBytes);    //// эта строка кода преобразует эти байты в строку в кодировке base64. Кодировка base64 представляет бинарные данные в виде текстовой строки, состоящей из ASCII-символов, что удобно для передачи данных, таких как изображения, в текстовых форматах.

            //    return base64Image;
            //}

            //builder.Entity<ShopItem>().HasData(
            //    new ShopItem
            //    {
            //        Id = 1,
            //        Name = "Black High Sneakers",
            //        Description = "most seller",
            //        Category = "Shoes",
            //        Price = 80.99,
            //        Image = path + @"\images\shopItems\Black High Sneakers.jpeg",
            //        Base64Image = getBase64Image(path + @"\images\shopItems\Black High Sneakers.jpg")
            //    },
            //    new ShopItem
            //    {
            //        Id = 2,
            //        Name = "Dunk Low Retro Sneakers",
            //        Description = "",
            //        Category = "Shoes",
            //        Price = 101.50,
            //        Image = path + @"\images\shopItems\Dunk Low Retro Sneakers.jpg",
            //        Base64Image = getBase64Image(path + @"\images\shopItems\Dunk Low Retro Sneakers.jpg")
            //    },
            //    new ShopItem
            //    {
            //        Id = 3,
            //        Name = "Faded Logo Tee",
            //        Description = "the hit of the summer",
            //        Category = "T-Shirt",
            //        Price = 30.50,
            //        Image = path + @"\images\shopItems\Faded Logo Tee.jpg",
            //        Base64Image = getBase64Image(path + @"\images\shopItems\Faded Logo Tee.jpg")
            //    },
            //    new ShopItem
            //    {
            //        Id = 4,
            //        Name = "Oversized T-Shirt",
            //        Description = "",
            //        Category = "T-Shirt",
            //        Price = 23.80,
            //        Image = path + @"\images\shopItems\Oversized T-Shirt.jpg",
            //        Base64Image = getBase64Image(path + @"\images\shopItems\Oversized T-Shirt.jpg")
            //    },
            //    new ShopItem
            //    {
            //        Id = 5,
            //        Name = "Сropped bomber jacket",
            //        Description = "",
            //        Category = "Coats & Jackets",
            //        Price = 71.99,
            //        Image = path + @"\images\shopItems\Сropped bomber jacket.jpg",
            //        Base64Image = getBase64Image(path + @"\images\shopItems\Сropped bomber jacket.jpg")
            //    },
            //    new ShopItem
            //    {
            //        Id = 6,
            //        Name = "Leather Varsity Jacket",
            //        Description = "the hit of the season",
            //        Category = "Coats & Jackets",
            //        Price = 65.75,
            //        Image = path + @"\images\shopItems\Leather Varsity Jacket.jpg",
            //        Base64Image = getBase64Image(path + @"\images\shopItems\Leather Varsity Jacket.jpg")
            //    }
            //);
        }
    }
}
