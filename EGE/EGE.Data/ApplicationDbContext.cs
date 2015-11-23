using System.Data.Entity;
using EGE.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace EGE.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public IDbSet<Credit> Credits { get; set; }
    }
}
