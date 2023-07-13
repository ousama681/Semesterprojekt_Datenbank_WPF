using Microsoft.EntityFrameworkCore;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.EntityConfiguration
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
