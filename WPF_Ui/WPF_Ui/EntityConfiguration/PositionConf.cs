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
    public class PositionConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().Property(p => p.ArticleId).IsRequired();
            modelBuilder.Entity<Position>().Property(p => p.Quantity).IsRequired();
            modelBuilder.Entity<Position>().Property(p => p.PriceNetto).IsRequired();

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
