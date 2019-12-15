﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLData
{
    public static class DbInitializer
    {
        public static void SeedDB(FitLineContext ctx)
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

                catSupplements.Categories = new List<Category> { catAmino, catProteins };
                ctx.Categories.Add(catSupplements);

                //Seeding products
                var prod1 = ctx.Products.Add(new Product
                {
                    Category = catProteins,
                    Name = "Whey Protein",
                    Description = "will make you into big guy",
                    Price = 20.14,
                    Amount = 500,
                    Rating = 4.5
                }).Entity;

                var prod2 = ctx.Products.Add(new Product
                {
                    Category = catProteins,
                    Name = "BCAA man",
                    Description = "You will regen faster",
                    Price = 18.22,
                    Amount = 200,
                    Rating = 4.1
                }).Entity;
            }
            
            SeedAdmins(ctx);
            ctx.SaveChanges();
        }

        private static void SeedAdmins(FitLineContext ctx)
        {
            ctx.Admins.Add(new Admin
            {
                Username = "Marek",
                Password = "Peasant",

            });

            ctx.Admins.Add(new Admin
            {
                Username = "Jano",
                Password = "Th3G0d42",

            });

            ctx.Admins.Add(new Admin
            {
                Username = "Szymon",
                Password = "ToCheckHowAlmightyOurProjectIs",

            });
        }
    }
}
