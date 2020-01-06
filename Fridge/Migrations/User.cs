using Fridge.Models;

namespace Fridge.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed partial class Configuration
    {
        /// <summary>
        /// Automatic data migration for the User table
        /// </summary>
        /// <param name="context"> The database connection </param>
        public void User(ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(i => i.Id,
                new ApplicationUser()
                {
                    Id = "661d5be6-2e0a-47a6-b17a-64662429e98c", Wallet = 35.00m, EmailConfirmed = false,
                    PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = false,
                    AccessFailedCount = 0, UserName = "admin"
                });

            context.SaveChanges();
        }
    }
}