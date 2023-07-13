using Microsoft.EntityFrameworkCore;

namespace WPF_Ui.Interfaces
{
    public interface IEntityConfiguration
    {
        void Visit(ModelBuilder modelBuilder);
    }
}
