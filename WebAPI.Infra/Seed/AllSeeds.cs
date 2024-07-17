using WebAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Infra.Data.Seed
{
    public static class ReseedsTables
    {
        public static void ReseedTables(this WebAPIContext context)
        {
            if (context.User.Where(x => x.Id > 1).Count() > 0)
            {
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Users', RESEED, 2)");
                context.SaveChanges();
            }

            if (context.Profile.Where(x => x.Id > 3).Count() > 0)
            {
                context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Profiles', RESEED, 4)");
                context.SaveChanges();
            }
        }
    }
}
