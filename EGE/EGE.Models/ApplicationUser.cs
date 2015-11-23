using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;


namespace EGE.Models
{
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Credit> credits; 
        public ApplicationUser()
        {
            this.credits= new HashSet<Credit>();
        }

        public virtual ICollection<Credit> Credits  {
            get { return this.credits; }
            set { this.credits = value; } 
        }
    }
}
