using Microsoft.EntityFrameworkCore;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.EntityConfiguration
{
    public class PositionConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().Property(p => p.ArticleId).IsRequired();
            modelBuilder.Entity<Position>().Property(p => p.Quantity).IsRequired();
            modelBuilder.Entity<Position>().Property(p => p.PriceNetto).IsRequired();
            modelBuilder.Entity<Position>().Property(p => p.OrderId).IsRequired();

            modelBuilder.Entity<Position>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Positions)
                .HasForeignKey(p => p.OrderId);

            modelBuilder.Entity<Position>()
                .HasOne(p => p.Article)
                .WithMany(a => a.Positions)
                .HasForeignKey(p => p.ArticleId);
        }
    }
}
