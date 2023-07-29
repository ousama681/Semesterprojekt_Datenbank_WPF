using Microsoft.EntityFrameworkCore;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.EntityConfiguration
{
    public class OrderConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Invoice)
            //    .WithOne(i => i.Order)
            //    .HasForeignKey(o => o.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
