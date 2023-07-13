using Microsoft.EntityFrameworkCore;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.EntityConfiguration
{
    public class CustomerConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(a => a.Nr).IsRequired();
            modelBuilder.Entity<Customer>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Customer>().Property(a => a.Email);
            modelBuilder.Entity<Customer>().Property(a => a.Website);
            modelBuilder.Entity<Customer>().Property(a => a.Password);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Town)
                .WithMany(t => t.Customers)
                .HasForeignKey(c => c.TownId);
        }
    }
}
