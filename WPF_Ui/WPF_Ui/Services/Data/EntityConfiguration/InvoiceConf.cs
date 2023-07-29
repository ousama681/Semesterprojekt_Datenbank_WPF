using Microsoft.EntityFrameworkCore;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.EntityConfiguration
{
    public class InvoiceConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().Property(a => a.Date);
            modelBuilder.Entity<Invoice>().Property(a => a.NetPrice);
            modelBuilder.Entity<Invoice>().Property(a => a.OrderId).IsRequired();

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Order)
                .WithOne(o => o.Invoice)
                .HasForeignKey<Invoice>(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
