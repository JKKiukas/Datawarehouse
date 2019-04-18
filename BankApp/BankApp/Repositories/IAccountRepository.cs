using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    interface IAccountRepository
    {
        void CreateAccount(Account account);
        List<Account> Read();
        List<Account> Read(long customerId);
        List<Account> ReadAccountWithCustomer();
        Account GetAccount(string IBAN);
        void DeleteAccount(string IBAN);
        void CreateTransaction(Transaction transaction);
    }
}