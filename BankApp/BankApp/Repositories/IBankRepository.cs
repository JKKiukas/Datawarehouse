using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    interface IBankRepository
    {
        void CreateBank(Bank bank);
        List<Bank> ReadBank();
        List<Customer> ReadBanksCustomers();
        Bank GetBank(long id);
        void UpdateBank(long id, Bank bank);
        void DeleteBank(long id);
    }
}