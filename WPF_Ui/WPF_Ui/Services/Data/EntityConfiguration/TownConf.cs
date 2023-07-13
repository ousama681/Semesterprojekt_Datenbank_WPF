using Microsoft.EntityFrameworkCore;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.EntityConfiguration
{
    public class TownConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Town>().Property(a => a.Id).IsRequired();
            modelBuilder.Entity<Town>().Property(a => a.ZipCode).IsRequired();
            modelBuilder.Entity<Town>().Property(a => a.City).IsRequired();
            modelBuilder.Entity<Town>().Property(a => a.Country).IsRequired();

            modelBuilder.Entity<Town>().HasMany(t => t.Customers).WithOne(c => c.Town).HasForeignKey(c => c.TownId);
        }
    }
}
