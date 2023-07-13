using Microsoft.EntityFrameworkCore;
using WPF_Ui.Interfaces;
using WPF_Ui.Models;

namespace WPF_Ui.EntityConfiguration
{
    public class OrderConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}
