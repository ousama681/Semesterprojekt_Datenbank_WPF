using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    public class PositionRepository : IPositionRepository
    {
        public Task<bool> AddAsync(Position item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Position item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Position>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Position> GetAsync(Position item)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Position item)
        {
            throw new NotImplementedException();
        }
    }
}
