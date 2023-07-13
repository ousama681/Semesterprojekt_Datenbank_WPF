using System.Collections.Generic;

namespace WPF_Ui.Services.Data.Interfaces
{
    public interface IDBUtility<T>
    {
        // CRUD Funktionen der Datenbank

        bool Create(T item);

        List<T> Read();
        T ReadSingle(T item);

        List<string> ReadFilter(List<string> item);

        void Update(T item);

        bool Delete(T item);

    }
}
