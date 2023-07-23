using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    public class ArticleGroupRepository : IArticleGroupRepository
    {
        private readonly DataContext _context;
        public ArticleGroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ArticleGroup item)
        {
            try
            {
                await _context.ArticleGroup.AddAsync(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(ArticleGroup item)
        {
            try
            {
                _context.ArticleGroup.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<List<ArticleGroup>> GetAllAsync()
        {
            try
            {
                return await _context.ArticleGroup.Include(a => a.Articles).ToListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<ArticleGroup>();
            }
        }

        public async Task<ArticleGroup> GetAsync(ArticleGroup item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.ArticleGroup.FirstOrDefaultAsync(c => c.Id == item.Id);
                    if (result != null)
                        return result;
                }
                return new ArticleGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new ArticleGroup();
            }
        }

        public async Task<ArticleGroup> GetByNameAsync(ArticleGroup item)
        {
            try
            {
                if (item != null && _context != null)
                {
                    var result = await _context.ArticleGroup.FirstOrDefaultAsync(c => c.Name == item.Name);
                    if (result != null)
                        return result;
                }
                return new ArticleGroup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new ArticleGroup();
            }
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ArticleGroup item)
        {
            try
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public async Task<List<Article>> GetArticlesOfArticleGroup(ArticleGroup articleGroup)
        {
            try
            {
                return await _context.Article.Include(a => a.ArticleGroup).Where(a => a.ArticleGroupId == articleGroup.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Article>();
            }
        }
    }
}
