using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Ui.Interfaces
{
    public interface IEntityConfiguration
    {
        void Visit(ModelBuilder modelBuilder);
    }
}
