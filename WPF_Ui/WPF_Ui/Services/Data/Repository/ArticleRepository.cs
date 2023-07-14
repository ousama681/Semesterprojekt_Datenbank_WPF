using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public Task<bool> AddAsync(Article item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Article item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetAsync(Article item)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Article item)
        {
            throw new NotImplementedException();
        }
    }
}
