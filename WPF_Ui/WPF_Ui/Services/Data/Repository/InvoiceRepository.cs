using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public Task<bool> AddAsync(Invoice item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Invoice item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Invoice>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> GetAsync(Invoice item)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Invoice item)
        {
            throw new NotImplementedException();
        }
    }
}
