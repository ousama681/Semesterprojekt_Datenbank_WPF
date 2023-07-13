using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Interfaces;
using WPF_Ui.Models;

namespace WPF_Ui.EntityConfiguration
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
