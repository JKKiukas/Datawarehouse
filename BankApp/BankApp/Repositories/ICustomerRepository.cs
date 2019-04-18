using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);
        List<Customer> Read();
        Customer GetCustomer(long id);
        void UpdateCustomer(long id, Customer customer);
        void DeleteCustomer(long id);
    }
}