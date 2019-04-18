using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace BankApp.Repositories
{
    class BankRepository : IBankRepository
    {
        private readonly BankdbContext _bankdbcontext = new BankdbContext();

        public void CreateBank(Bank bank)
        {
            string sql = $"Insert into bank (ID, Name, BIC)" +
                         $"Values ({bank.Id}, {bank.Name}, {bank.BIC})";

            _bankdbcontext.Bank.Add(bank);
            _bankdbcontext.SaveChanges();
        }

        public void DeleteBank(long id)
        {
            var deleteBank = _bankdbcontext.Bank.FirstOrDefault(b => b.Id == id);
            
            if(deleteBank != null)
            {
                _bankdbcontext.Bank.Remove(deleteBank);
                _bankdbcontext.SaveChanges();
            }

            else
            {
                Console.WriteLine("\nPankkia ei voi poistaa, koska sitä ei ole olemassa.");
            }
        }

        public List<Bank> ReadBank()
        {
            var readBank = _bankdbcontext.Bank.ToListAsync().Result;
            return readBank;
        }

        public Bank GetBank(long id)
        {
            var readBank = _bankdbcontext.Bank
                .FirstOrDefault(b => b.Id == id);
            return readBank;
        }

        public void UpdateBank(long id, Bank bank)
        {
            var updateBank = GetBank(id);

            if(updateBank != null)
            {
                _bankdbcontext.Update(bank);
                _bankdbcontext.SaveChanges();
            }

            else
            {
                Console.WriteLine();
            }
        }

        public List<Customer> ReadBanksCustomers()
        {
            var banksCustomers = _bankdbcontext.Customer.Include(b => b.Bank).ToList();
            return banksCustomers;
        }
    }
}