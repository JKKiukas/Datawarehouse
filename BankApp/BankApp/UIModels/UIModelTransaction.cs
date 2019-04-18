using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.UIModels
{
    class UIModelTransaction
    {
        private static readonly TransactionRepository _transactionRepository = new TransactionRepository();

        public void ReadTransaction()
        {
            var transaction = _transactionRepository.Read();

            foreach (var t in transaction)
            {
                if (t == null)
                {
                    Console.WriteLine("Asiakkaan tilisiirtoja ei löytynyt.");
                }

                else
                {
                    Console.WriteLine($"{t.Amount} euroa on siirretty tilille {t.IBAN} ajalla {t.TimeStamp}.");
                }
            }
            Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
        }
    }
}
