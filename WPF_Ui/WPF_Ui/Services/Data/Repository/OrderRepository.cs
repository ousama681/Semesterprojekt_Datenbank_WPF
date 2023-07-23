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
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> AddAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            try
            {
                return await _context.Order
                    .Include(a => a.Customer)
                    .Include(a => a.Customer.Town)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Order>();
            }
        }

        public Task<Order> GetAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
