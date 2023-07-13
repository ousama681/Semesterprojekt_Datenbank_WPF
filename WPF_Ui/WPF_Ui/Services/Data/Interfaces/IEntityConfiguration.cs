using Microsoft.EntityFrameworkCore;

namespace WPF_Ui.Services.Data.Interfaces
{
    public interface IEntityConfiguration
    {
        void Visit(ModelBuilder modelBuilder);
    }
}
