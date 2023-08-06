using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> DeleteAsync(Invoice item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.Invoice.FirstOrDefaultAsync(c => c.Id == item.Id);
                    if (result != null)
                    {
                        _context.Invoice.Remove(result);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<List<Invoice>> GetAllAsync()
        {
            try
            {
                if (_context != null)
                {
                    var result = await _context.Invoice.Include(c => c.Customer).ThenInclude(c => c.Town).Include(c => c.Order).ToListAsync();
                    await _context.SaveChangesAsync();
                    return result;
                }
                return new List<Invoice>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Invoice>();
            }
        }

        public async Task<Invoice> GetAsync(Invoice item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.Invoice.FirstOrDefaultAsync(c => c.Id == item.Id);
                    if (result != null)
                        return result;
                }
                return new Invoice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Invoice();
            }
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Invoice item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = _context.Invoice.Update(item);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
