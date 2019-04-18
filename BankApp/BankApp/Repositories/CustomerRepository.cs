using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace BankApp.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly BankdbContext _bankdbcontext = new BankdbContext();

        public void CreateCustomer(Customer customer)
        {
            string sql = $"Insert into customer (ID, Firstname, Lastname, BankID)" +
                         $"Values ({customer.Id}, {customer.Firstname}, {customer.BankId})";

            _bankdbcontext.Customer.Add(customer);
            _bankdbcontext.SaveChanges();
        }

        public void DeleteCustomer(long id)
        {
            var deleteCustomer = _bankdbcontext.Customer.FirstOrDefault(c => c.Id == id);

            if(deleteCustomer != null)
            {
                _bankdbcontext.Customer.Remove(deleteCustomer);
                _bankdbcontext.SaveChanges();
            }

            else
            {
                Console.WriteLine("\nAsiakasta ei voi poistaa, koska sitä ei ole olemassa.");
            }
        }

        public List<Customer> Read()
        {
            var readCustomer = _bankdbcontext.Customer.ToListAsync().Result;
            return readCustomer;
        }

        internal void CreateCustomer(int userInput)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(long id)
        {
            var readCustomer = _bankdbcontext.Customer
                .FirstOrDefault(c => c.Id == id);
            return readCustomer;
        }

        public void UpdateCustomer(long id, Customer customer)
        {
            var updateCustomer = GetCustomer(id);

            if(updateCustomer != null)
            {
                _bankdbcontext.Update(customer);
                _bankdbcontext.SaveChanges();
            }

            else
            {
                Console.WriteLine();
            }
        }
    }
}