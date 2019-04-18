using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace BankApp.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly BankdbContext _bankdbcontext = new BankdbContext();

        public List<Transaction> Read()
        {
            var readTransaction = _bankdbcontext.Transaction.ToList();
            return readTransaction;
        }

        public Transaction GetTransactionById(long id)
        {
            var transaction = _bankdbcontext.Transaction.FirstOrDefault(t => t.Id == id);
            return transaction;
        }

        public List<Transaction> ReadTrasactionById(long id)
        {
            var readTransactonById = _bankdbcontext.Transaction.Where(t => t.Id == id).ToList();
            return readTransactonById;
        }
    }
}