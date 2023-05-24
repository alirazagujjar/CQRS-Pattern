using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerRepository : ICustomerRepository
    {
        internal CustomerDBContext context;

        public CustomerRepository(CustomerDBContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await context.Customers.FindAsync(id);
        }
        public async Task<bool> Add(Customer entity)
        {
            context.Customers.AddAsync(entity);
            return true;
        }

        public void Delete(int id)
        {
            Customer entityToDelete = context.Customers.Find(id);
            Delete(entityToDelete);
        }
        public void Delete(Customer entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                context.Customers.Attach(entityToDelete);
            }
            context.Customers.Remove(entityToDelete);
        }

        public async Task<List<Customer>> GetAsync()
        {
            var custiomer = await context.Customers.ToListAsync();
            return custiomer;
        }
        public void Update(Customer entityToUpdate)
        {
            context.Customers.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        
    }
}
