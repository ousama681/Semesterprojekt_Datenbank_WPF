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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Customer item)
        {
            try
            {
                if(item != null && _context != null)
                {
                    await _context.Customer.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }           
        }

        public async Task<bool> DeleteAsync(Customer item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.Customer.FirstOrDefaultAsync(c => c.Id == item.Id);
                    if (result != null)
                    {
                        _context.Customer.Remove(result);
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

        public async Task<List<Customer>> GetAllAsync()
        {
            try
            {
                if (_context != null)
                {
                    var result = await _context.Customer.Include(c => c.Town).Include(c => c.Orders).Include(c => c.Invoices).ToListAsync();
                    await _context.SaveChangesAsync();
                    return result;
                }
                return new List<Customer>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Customer>();
            }
        }

        public async Task<Customer> GetAsync(Customer item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.Customer.FirstOrDefaultAsync(c => c.Id == item.Id);
                    if (result != null)
                        return result;
                }
                return new Customer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Customer();
            }
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Customer item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = _context.Customer.Update(item);
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
