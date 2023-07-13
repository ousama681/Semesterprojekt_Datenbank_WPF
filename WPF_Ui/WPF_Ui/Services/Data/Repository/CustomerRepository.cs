using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Ui.Models;
using WPF_Ui.Services.Data.Interfaces;

namespace WPF_Ui.Services.Data.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository() 
        {

        }
        public Task<bool> AddAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetAsync(Customer item)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetFilteredAsync(List<string> item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
