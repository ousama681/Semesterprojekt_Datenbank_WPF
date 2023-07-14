using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    public class MWSTRepository : IMWSTRepository
    {
        public Task<bool> AddAsync(MWST item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(MWST item)
        {
            throw new NotImplementedException();
        }

        public Task<List<MWST>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MWST> GetAsync(MWST item)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MWST item)
        {
            throw new NotImplementedException();
        }
    }
}
