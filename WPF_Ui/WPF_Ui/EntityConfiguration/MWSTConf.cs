using Microsoft.EntityFrameworkCore;
using System;
using WPF_Ui.Interfaces;
using WPF_Ui.Models;

namespace WPF_Ui.EntityConfiguration
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
