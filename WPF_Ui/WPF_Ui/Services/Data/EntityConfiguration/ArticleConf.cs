using Microsoft.EntityFrameworkCore;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.EntityConfiguration
{
    public class ArticleConf : DbContext, IEntityConfiguration
    {

        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<Article>().Property(a => a.Nr).IsRequired();
            modelBuilder.Entity<Article>().Property(a => a.Price).IsRequired();
            modelBuilder.Entity<Article>().Property(a => a.DateTime).IsRequired();

            modelBuilder.Entity<Article>().HasOne(a => a.ArticleGroup)
                .WithMany(a => a.Articles).HasForeignKey(a => a.ArticleGroupId);

            modelBuilder.Entity<Article>().HasOne(a => a.MWST)
                .WithMany(m => m.Articles).HasForeignKey(a => a.Mwstid);


        }
    }
}
