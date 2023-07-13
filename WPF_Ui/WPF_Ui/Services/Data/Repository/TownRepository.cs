using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    internal class TownRepository : ITownRepository
    {
        public Task<bool> AddAsync(Town item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Town item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Town>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Town> GetAsync(Town item)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Town item)
        {
            throw new NotImplementedException();
        }
    }
}
