using AppCore.Helpers;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLData
{
    public static class DbInitializer
    {
        

        public static void SeedDB(FitLineContext ctx, IAuthenticationHelper authenticationHelper)
        {

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            if (ctx.Users.Any())
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

                var catGainers = ctx.Categories.Add(new Category
                {
                    Name = "Gainers",
                    ParentCategory = catSupplements,
                }).Entity;


                var catCarbohydrates = ctx.Categories.Add(new Category
                {
                    Name = "Carbohydrates",
                    ParentCategory = catSupplements,
                }).Entity;

                var catMana = ctx.Categories.Add(new Category
                {
                    Name = "Mana",
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

                var catShirts = ctx.Categories.Add(new Category
                {
                    Name = "Shirts",
                    ParentCategory = catClothing,
                }).Entity;


                var catPants = ctx.Categories.Add(new Category
                {
                    Name = "Pants",
                    ParentCategory = catClothing,
                }).Entity;


                var catSocks = ctx.Categories.Add(new Category
                {
                    Name = "Socks",
                    ParentCategory = catClothing,
                }).Entity;

                var catMachines = ctx.Categories.Add(new Category
                {
                    Name = "Machines",
                    ParentCategory = null,
                }).Entity;

                var catTwr = ctx.Categories.Add(new Category
                {
                    Name = "Tower",
                    ParentCategory = catMachines,
                }).Entity;


                var catSmthMach= ctx.Categories.Add(new Category
                {
                    Name = "Smith Machine",
                    ParentCategory = catMachines,
                }).Entity;

                var catBarbells = ctx.Categories.Add(new Category
                {
                    Name = "Barbells",
                    ParentCategory = null,
                }).Entity;

                var catRacks = ctx.Categories.Add(new Category
                {
                    Name = "Racks",
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

                var supp3 = ctx.Suppliers.Add(new Supplier
                {
                    Name = "BodyWorld"
                }).Entity;

                var supp4 = ctx.Suppliers.Add(new Supplier
                {
                    Name = "StillMass"
                }).Entity;

                var supp5= ctx.Suppliers.Add(new Supplier
                {
                    Name = "Marekové sypačky"
                }).Entity;


                //Seeding products
                var prod1 = ctx.Products.Add(new Product
                {
                    Category = catProteins,
                    Name = "Whey Protein",
                    Description = "will make you into big guy like me",
                    Price = 40.99,
                    Amount = 2500,
                    Rating = 4.5,
                    Supplier = supp1
                }).Entity;

                var image1 = ctx.ProductImages.Add(new ProductImage

                {
                    Product = prod1,
                    url = "https://body-stuff.dk/media/cache/product_original/product-images/46/8/scitec_100_whey_protein_pro_2350g_chocolate_hazelnut1531142017.6064.jpg?1531142017"
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

                var prod3 = ctx.Products.Add(new Product
                {
                    Category = catProteins,
                    Name = "Soy Protein",
                    Description = "Only girls are using this product",
                    Price = 20.14,
                    Amount = 800,
                    Rating = 2.5,
                    Supplier = supp3
                }).Entity;

                var image3 = ctx.ProductImages.Add(new ProductImage

                {
                    Product = prod3,
                    url = "https://www.bodyworld.cz/images/products/protein-soy-80-protein-weider-800-g-detail.jpg"
                }).Entity;


                var prod4 = ctx.Products.Add(new Product
                {
                    Category = catProteins,
                    Name = "Whey Protein",
                    Description = "Smaller portion for smaller ... ",
                    Price = 20.99,
                    Amount = 870,
                    Rating = 4.5,
                    Supplier = supp1
                }).Entity;

                var image4 = ctx.ProductImages.Add(new ProductImage

                {
                    Product = prod4,
                    url = "https://sporttimekka.fi/wp-content/uploads/2018/12/Scitec-Whey-Protein-Professional-ISO.jpg"
                }).Entity;


                var prod5 = ctx.Products.Add(new Product
                {
                    Category = catRacks,
                    Name = "Basic Rack",
                    Description = "Totally not for this webpage",
                    Price = 100,
                    Amount = 1,
                    Rating = 5,
                    Supplier = supp1
                }).Entity;

                var image5 = ctx.ProductImages.Add(new ProductImage

                {
                    Product = prod5,
                    url = "https://5.imimg.com/data5/PI/LH/MY-4092020/adjustable-racks-500x500.png"
                }).Entity;
            }

           /* for (int i = 0; i < 30; i++)




            {
                var forCat = ctx.Categories.Add(new Category
                {
                    Name = "Clothing",
                    ParentCategory = null,
                }).Entity;

                var forSupp = ctx.Suppliers.Add(new Supplier
                {
                    Name = "Scitec"
                }).Entity;


                var forProd = ctx.Products.Add(new Product
                {
                    Category = forCat,
                    Name = "Product" +i,
                    Description = "Mocked tool",
                    Price = 100,
                    Amount = 1,
                    Rating = 5,
                    Supplier = forSupp
                }).Entity;

                var forImage = ctx.ProductImages.Add(new ProductImage

                {
                    Product = forProd,
                    url = "https://5.imimg.com/data5/PI/LH/MY-4092020/adjustable-racks-500x500.png"
                }).Entity;
            }*/


        

            //Seeding Admins
            string password1 = "PesoLover";
            string password2 = "TheLazyOne";
            string password3 = "1234";
            byte[] passwordHashMarek, passwordSaltMarek, passwordHashJan, passwordSaltJan, passwordHashSz, passwordSaltSz;
            authenticationHelper.CreatePasswordHash(password1, out passwordHashMarek, out passwordSaltMarek);
            authenticationHelper.CreatePasswordHash(password2, out passwordHashJan, out passwordSaltJan);
            authenticationHelper.CreatePasswordHash(password3, out passwordHashSz, out passwordSaltSz);
            ctx.Users.Add(new User
            {
                Username = "Marek",
                PasswordHash = passwordHashMarek,
                PasswordSalt = passwordSaltMarek,
                IsAdmin = true

            });

            ctx.Users.Add(new User
            {
                Username = "Jano",
                PasswordHash = passwordHashJan,
                PasswordSalt = passwordSaltJan,
                IsAdmin = true

            }) ;

            ctx.Users.Add(new User
            {
                Username = "Szymon",
                PasswordHash = passwordHashSz,
                PasswordSalt = passwordSaltSz,
                IsAdmin = false

            });

            ctx.SaveChanges();
        }


     
    }
}
