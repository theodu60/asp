using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Muscu.Models;

namespace Muscu.DAL
{
    public class MuscuInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuscuContext>
    {
        protected override void Seed(MuscuContext context)
        {
            var roles = new List<Roles>
            {
            new Roles{nom="ADMINISTRATEUR"},
            new Roles{nom="USER"},
            };

            roles.ForEach(s => context.Roles.Add(s));
            context.SaveChanges();
           
        }
    }
}