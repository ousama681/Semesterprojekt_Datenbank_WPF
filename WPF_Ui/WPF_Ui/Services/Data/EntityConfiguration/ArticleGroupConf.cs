using Microsoft.EntityFrameworkCore;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.EntityConfiguration
{
    public class ArticleGroupConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ArticleGroup>().Property(a => a.Name).IsRequired();
            //modelBuilder.Entity<ArticleGroup>().Property(a => a.ParentId);

            // Configure ArticleGroup entity
            modelBuilder.Entity<ArticleGroup>()
                .HasKey(ag => ag.Id);

            modelBuilder.Entity<ArticleGroup>()
                .Property(ag => ag.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<ArticleGroup>()
                .HasMany(ag => ag.Articles)
                .WithOne(a => a.ArticleGroup)
                .HasForeignKey(a => a.ArticleGroupId)
                .OnDelete(DeleteBehavior.Cascade); // or Cascade if you want to delete related articles on group deletion

            // Configure self-referencing relationship for Parent-Children
            modelBuilder.Entity<ArticleGroup>()
                .HasOne(ag => ag.Parent)
                .WithMany(ag => ag.Children)
                .HasForeignKey(ag => ag.ParentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade); // or Cascade if you want to delete children on parent deletion

        }
    }
}
