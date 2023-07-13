using Microsoft.EntityFrameworkCore;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.EntityConfiguration
{
    public class MWSTConf : IEntityConfiguration
    {
        public void Visit(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MWST>()
                .Property(m => m.TaxValue)
                .IsRequired();
        }
    }
}
