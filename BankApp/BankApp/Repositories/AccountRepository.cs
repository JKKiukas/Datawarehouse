using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace BankApp.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly BankdbContext _bankdbcontext = new BankdbContext();

        public void CreateAccount(Account account)
        {
            string sql = $"Instert into account (IBAN, Name, BankId, CustomerId, Balance)" +
                         $"Values ({account.IBAN}, {account.Name}, {account.BankId}, {account.CustomerId}, {account.Balance})";

            _bankdbcontext.Account.Add(account);
            _bankdbcontext.SaveChanges();
        }

        public void CreateTransaction(Transaction transaction)
        {
            try
            {
                _bankdbcontext.Transaction.Add(transaction);
                var account = GetAccount(transaction.IBAN);
                account.Balance += transaction.Amount;
                

                _bankdbcontext.Account.Update(account);
                _bankdbcontext.SaveChanges();   
            }

            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void DeleteAccount(string IBAN)
        {
            var deleteAccount = _bankdbcontext.Account.FirstOrDefault(a => a.IBAN == IBAN);

            if(deleteAccount != null)
            {
                _bankdbcontext.Account.Remove(deleteAccount);
                _bankdbcontext.SaveChanges();
            }

            else
            {
                Console.WriteLine("\nTiliä ei voi poistaa, koska sitä ei ole olemassa.");
            }
        }

        public List<Account> Read()
        {
            var readAccount = _bankdbcontext.Account.ToList();
            return readAccount;
        }

        public List<Account> ReadAccountWithCustomer()
        {
            var accountsWithCustomer = _bankdbcontext.Account.Include(a => a.Customer).ToList();
            return accountsWithCustomer;
        }

        public Account GetAccount(string iban)
        {
            var readAccount = _bankdbcontext.Account.FirstOrDefault(a => a.IBAN == iban);
            return readAccount;
        }

        public List<Account> Read(long customerId)
        {
            var readAccount = _bankdbcontext.Account.Where(a => a.CustomerId == customerId).ToList();
            return readAccount;
        }
    }
}