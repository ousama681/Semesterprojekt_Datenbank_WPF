using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    public class ArticleGroupRepository : IArticleGroupRepository
    {
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

        public Task<ArticleGroup> GetAsync(ArticleGroup item)
        {
            throw new NotImplementedException();
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
