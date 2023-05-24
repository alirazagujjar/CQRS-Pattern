using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerRepository
    {
        void Delete(int id);
        Task<List<Customer>> GetAsync();
        Task<bool> Add(Customer entity);
        void Update(Customer entityToUpdate);
        Task SaveChangesAsync();
        Task<Customer> GetByIdAsync(int id);
    }
}
