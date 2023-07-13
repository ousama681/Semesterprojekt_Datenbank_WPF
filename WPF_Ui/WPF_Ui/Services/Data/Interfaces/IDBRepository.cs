using System.Collections.Generic;
using System.Threading.Tasks;

namespace WPF_Ui.Services.Data.Interfaces
{
    public interface IDBRepository<T>
    {
        // CRUD Funktionen der Datenbank

        Task<bool> AddAsync(T item);

        Task<List<T>> GetAllAsync();

        Task<T> GetAsync(T item);

        Task<List<string>> GetFilteredAsync(List<string> item);

        Task UpdateAsync(T item);

        Task<bool> DeleteAsync(T item);

    }
}
