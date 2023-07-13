using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        public Task<bool> AddAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetAsync(Order item)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
