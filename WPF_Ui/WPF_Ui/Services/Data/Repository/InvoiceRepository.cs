using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContext _context;

        public InvoiceRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Invoice item)
        {
            try
            {
                await _context.Invoice.AddAsync(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return true;
            }
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
