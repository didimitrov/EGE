using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGE.Data.Repositories;
using EGE.Models;

namespace EGE.Data.UoW
{
    public interface IUowData
    {
        IRepository<Credit> Credits { get; }
        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}
