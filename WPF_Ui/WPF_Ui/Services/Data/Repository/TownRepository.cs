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
    public class TownRepository : ITownRepository
    {
        private readonly DataContext _context;
        public TownRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Town item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    await _context.Town.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Town item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.Town.FirstOrDefaultAsync(c => c.Id == item.Id);
                    if (result != null)
                    {
                        _context.Town.Remove(result);
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

        public async Task<List<Town>> GetAllAsync()
        {
            try
            {
                if (_context != null)
                {
                    var result = await _context.Town.Include(c => c.Customers).ToListAsync();
                    await _context.SaveChangesAsync();
                    return result;
                }
                return new List<Town>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Town>();
            }
        }

        public async Task<Town> GetAsync(Town item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.Town.FirstOrDefaultAsync(c => c.ZipCode == item.ZipCode && c.City.ToLower() == item.City.ToLower());
                    if (result != null)
                        return result;
                }
                return new Town();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Town();
            }
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Town item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = _context.Town.Update(item);
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