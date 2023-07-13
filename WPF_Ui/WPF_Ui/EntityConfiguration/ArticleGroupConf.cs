using Microsoft.EntityFrameworkCore;
using WPF_Ui.Interfaces;
using WPF_Ui.Models;

namespace WPF_Ui.EntityConfiguration
{
    public class ArticleGroupConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleGroup>().Property(a => a.Name).IsRequired();
            modelBuilder.Entity<ArticleGroup>().Property(a => a.ParentId);
        }
    }
}
