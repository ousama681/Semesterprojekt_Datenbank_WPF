using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using WPF_Ui.Services.Data.EntityConfiguration;
using WPF_Ui.Models;

namespace WPF_Ui.Services.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ArticleGroup> ArticleGroup { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Town> Town { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<MWST> MWST { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionStringByName("connection"));
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Debug);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ArticleConf().Visit(modelBuilder);
            new ArticleGroupConf().Visit(modelBuilder);
            new CustomerConf().Visit(modelBuilder);
            new InvoiceConf().Visit(modelBuilder);
            new MWSTConf().Visit(modelBuilder);
            new OrderConf().Visit(modelBuilder);
            new PositionConf().Visit(modelBuilder);
            new TownConf().Visit(modelBuilder);

            modelBuilder
                .Entity<Customer>()
                .ToTable("Customer", c => c.IsTemporal());
        }
        public static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }
    }
}
