namespace GMACCloudAPI.Migrations
{
    using GMACCloudAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GMACCloudAPI.Models.GMACServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GMACCloudAPI.Models.GMACServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Users.AddOrUpdate(u => u.LoginAccount,
                new User { LoginAccount = "0001", Password = "0001" },
                new User { LoginAccount = "0002", Password = "0002" }
            );

            context.AssetRegistrations.AddOrUpdate(a => a.VIN,
                new AssetRegistration { VIN = "1G2NW12E25M108434", RFIDCode = "1234567890128", Dealer = "1111", OperatorLoginAccount = "0001", CreatedOn = "2015-12-09T13:45:30.05" },
                new AssetRegistration { VIN = "1G2NW12E25M108435", RFIDCode = "1234567890138", Dealer = "1111", OperatorLoginAccount = "0001", CreatedOn = "2015-12-09T13:46:30.05" },
                new AssetRegistration { VIN = "1G2NW12E25M108436", RFIDCode = "1234567890148", Dealer = "1111", OperatorLoginAccount = "0001", CreatedOn = "2015-12-09T13:47:30.05" },
                new AssetRegistration { VIN = "1G2NW12E25M208434", RFIDCode = "2234567890128", Dealer = "2222", OperatorLoginAccount = "0002", CreatedOn = "2015-12-09T13:47:30.05" },
                new AssetRegistration { VIN = "1G2NW12E25M208435", RFIDCode = "2234567890138", Dealer = "2222", OperatorLoginAccount = "0002", CreatedOn = "2015-12-09T13:47:30.05" }
            );

            context.AssetCheckJobs.AddOrUpdate(a => a.TaskCode,
                new AssetCheckJob { TaskCode = "TP-20151210-001", Dealer = "1111", OperatorLoginAccount = "0001", CreatedOn = "2015-12-10T13:47:30.05" },
                new AssetCheckJob { TaskCode = "TP-20151210-002", Dealer = "2222", OperatorLoginAccount = "0002", CreatedOn = "2015-12-11T13:47:30.05" }
            );

            context.AssetCheckItems.AddOrUpdate(a => new { a.TaskCode, a.VIN },
                new AssetCheckItem { TaskCode = "TP-20151210-001", VIN = "1G2NW12E25M108434", RFIDCode = "1234567890128" },
                new AssetCheckItem { TaskCode = "TP-20151210-001", VIN = "1G2NW12E25M108435", RFIDCode = "1234567890138" },
                new AssetCheckItem { TaskCode = "TP-20151210-001", VIN = "1G2NW12E25M108436", RFIDCode = "1234567890148" },
                new AssetCheckItem { TaskCode = "TP-20151210-002", VIN = "1G2NW12E25M208434", RFIDCode = "2234567890128" },
                new AssetCheckItem { TaskCode = "TP-20151210-002", VIN = "1G2NW12E25M208435", RFIDCode = "2234567890138" }
            );
        }
    }
}
