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

        public async Task<bool> AddAsync(Order item)
        {
            try
            {
                await _context.Order.AddAsync(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Order item)
        {
            try
            {
                _context.Order.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
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

        public async Task<Order> GetAsync(Order item)
        {
            try
            {
                return await _context.Order
                    .Where(o => o.Id == item.Id)
                    .Include(o => o.Positions)
                    .Include(o => o.Invoice)
                    .SingleAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Order();
            }
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Order item)
        {
            try
            {
                _context.Order.Update(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
