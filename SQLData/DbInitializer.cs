using AppCore.Helpers;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLData
{
    public class DbInitializer
    {
        private  IAuthenticationHelper authenticationHelper;

        public DbInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }
        public void SeedDB(FitLineContext ctx )
        {

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            if (ctx.Admins.Any())
            {
                return;   // DB has been seeded
            }

            //Seeding content
            {
                //Seeding Categories
                var catSupplements = new Category
                {
                    Name = "Supplements",
                };

                var catProteins = ctx.Categories.Add(new Category
                {
                    Name = "Proteins",
                    ParentCategory = catSupplements,
                }).Entity;

                var catAmino = ctx.Categories.Add(new Category
                {
                    Name = "Amino Acids",
                    ParentCategory = catSupplements,
                }).Entity;

                var catClothing = ctx.Categories.Add(new Category
                {
                    Name = "Clothing",
                    ParentCategory = null,
                }).Entity;

                catSupplements.Children = new List<Category> { catAmino, catProteins };
                ctx.Categories.Add(catSupplements);

                //Seeding Suppliers
                var supp1 = ctx.Suppliers.Add(new Supplier
                {
                    Name = "Weider"
                }).Entity;

                //Seeding Suppliers
                var supp2 = ctx.Suppliers.Add(new Supplier
                {
                    Name = "Scitec"
                }).Entity;

                //Seeding products
                var prod1 = ctx.Products.Add(new Product
                {
                    Category = catProteins,
                    Name = "Whey Protein",
                    Description = "will make you into big guy",
                    Price = 20.14,
                    Amount = 500,
                    Rating = 4.5,
                    Supplier = supp1
                }).Entity;

                var prod2 = ctx.Products.Add(new Product
                {
                    Category = catAmino,
                    Name = "BCAA man",
                    Description = "You will regen faster",
                    Price = 18.22,
                    Amount = 200,
                    Rating = 4.1,
                    Supplier = supp2
                }).Entity;
            }

            //Seeding Admins
            string password1 = "PesoLover";
            string password2 = "TheLazyOne";
            string password3 = "1234";
            byte[] passwordHashMarek, passwordSaltMarek, passwordHashJan, passwordSaltJan, passwordHashSz, passwordSaltSz;
            authenticationHelper.CreatePasswordHash(password1, out passwordHashMarek, out passwordSaltMarek);
            authenticationHelper.CreatePasswordHash(password2, out passwordHashJan, out passwordSaltJan);
            authenticationHelper.CreatePasswordHash(password3, out passwordHashSz, out passwordSaltSz);
            ctx.Admins.Add(new Admin
            {
                Username = "Marek",
                PasswordHash = passwordHashMarek,
                PasswordSalt = passwordSaltMarek,

            });

            ctx.Admins.Add(new Admin
            {
                Username = "Jano",
                PasswordHash = passwordHashJan,
                PasswordSalt = passwordSaltJan,

            });

            ctx.Admins.Add(new Admin
            {
                Username = "Szymon",
                PasswordHash = passwordHashSz,
                PasswordSalt = passwordSaltSz,

            });

            ctx.SaveChanges();
        }


     
    }
}
