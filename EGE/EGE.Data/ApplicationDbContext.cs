using System.Data.Entity;
using EGE.Data.Migrations;
using EGE.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace EGE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<Credit> Credits { get; set; }
    }
}
