using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLData
{
    public static class DbInitializer
    {
        public static void SeedSB(FitLineContext ctx)
        {


            ctx.Database.EnsureCreated();
            if (ctx.Admins.Any())
            {
                return;   // DB has been seeded
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
                Password = "The3G0d42",

            });

            ctx.Admins.Add(new Admin
            {
                Username = "Szymon",
                Password = "ToCheckHowAlmightyOurProjectIs",

            });
        }
    }
}
