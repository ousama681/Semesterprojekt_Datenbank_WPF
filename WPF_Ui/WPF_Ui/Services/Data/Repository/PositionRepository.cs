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
    public class PositionRepository : IPositionRepository
    {
        private readonly DataContext _context;

        public PositionRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> AddAsync(Position item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Position item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Position>> GetAllAsync()
        {
            try
            {
                return await _context.Position
                    .Include(a => a.Article)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Position>();
            }
        }

        public Task<Position> GetAsync(Position item)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Position>> GetOrderPositions(Order order)
        {
            try
            {
                return await _context.Position
                    .Include(p => p.Article)
                    .Where(p => p.OrderId == order.Id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Position>();
            }
        }

        public Task UpdateAsync(Position item)
        {
            throw new NotImplementedException();
        }
    }
}
