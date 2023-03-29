using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskOfc.Model;

namespace TaskOfc.Data
{
    public class Applicationdbcontext:DbContext
    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext> ioption):base(ioption)
        {

        }
        public DbSet<Employe> Employes { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.CurrentValues.SetValues(new { IsDeleted = true });
                }
            }
            return base.SaveChanges();
        }


    }
}
