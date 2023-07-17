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
    public class ArticleGroupRepository : IArticleGroupRepository
    {
        private readonly DataContext _context;
        public ArticleGroupRepository(DataContext context)
        {
            _context = context;
        }

        public Task<bool> AddAsync(ArticleGroup item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(ArticleGroup item)
        {
            throw new NotImplementedException();
        }

        public Task<List<ArticleGroup>> GetAllAsync()
        {
            throw new NotImplementedException();
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

        public Task UpdateAsync(ArticleGroup item)
        {
            throw new NotImplementedException();
        }
    }
}
