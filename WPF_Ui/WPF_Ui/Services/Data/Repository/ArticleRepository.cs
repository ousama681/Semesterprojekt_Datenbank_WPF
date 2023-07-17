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
    public class ArticleRepository : IArticleRepository
    {
        private readonly DataContext _context;
        public ArticleRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Article item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    await _context.Article.AddAsync(item);
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

        public async Task<bool> DeleteAsync(Article item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.Article.FirstOrDefaultAsync(c => c.Id == item.Id);
                    if (result != null)
                    {
                        _context.Article.Remove(result);
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

        public async Task<List<Article>> GetAllAsync()
        {
            try
            {
                if (_context != null)
                {
                    var result = await _context.Article.Include(c => c.ArticleGroup).Include(c => c.MWST).ToListAsync();
                    await _context.SaveChangesAsync();
                    return result;
                }
                return new List<Article>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Article>();
            }
        }

        public async Task<Article> GetAsync(Article item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.Article.FirstOrDefaultAsync(c => c.Id == item.Id);
                    if (result != null)
                        return result;
                }
                return new Article();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new Article();
            }
        }

        public async Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Article item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = _context.Article.Update(item);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int MaxNr()
        {
            var number = (from art in _context.Article
                          select art.Nr).Max();
            return number + 1;
        }
    }
}
