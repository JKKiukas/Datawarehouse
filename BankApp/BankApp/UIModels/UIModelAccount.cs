using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.UIModels
{
    class UIModelAccount
    {
        private static readonly AccountRepository _accountRepository = new AccountRepository();

        public void ReadAccount()
        {
            var accounts = _accountRepository.Read();

            foreach (var a in accounts)
            {
                if(a == null)
                {
                    Console.WriteLine("Tiliä ei löytynyt.");
                }

                else
                {
                    Console.WriteLine($"\nTilin IBAN: {a.IBAN}" +
                                      $"\nTilin nimi: {a.Name}" +
                                      $"\nTilin ID: {a.BankId}"+
                                      $"\nTilin halitijan ID: {a.CustomerId}" +
                                      $"\nTilin saldo: {a.Balance} euroa");
                }
            }

            Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
        }

        public void ReadAccountWithCustomer()
        {
            var accountsWithCustomer = _accountRepository.ReadAccountWithCustomer();

            foreach (var a in accountsWithCustomer)
            {
                Console.WriteLine($"Tilin {a.IBAN},jonka nimi on {a.Name}, omistaa {a.Customer.Firstname} {a.Customer.Lastname}. {$"Tilin saldo on {a.Balance} euroa."}");
            }

            Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
        }

        public void CreateAccount()
        {
            Random rnd = new Random();
            Account account = new Account();
            account.IBAN = $"FI{rnd.Next(10000000, 99999999)}";
            account.Name = "Talletustili";
            account.BankId = 1;
            account.CustomerId = 8;
            account.Balance = 5000;

            _accountRepository.CreateAccount(account);
            Console.WriteLine("Tilin luonti onnistui.");
            Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
        }

        public void DeleteAccount(string IBAN)
        {
            _accountRepository.DeleteAccount(IBAN);

            Console.WriteLine("\nTili on poistettu.");
            Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
        }

        public void CreateTransaction()
        {
            Transaction transaction = new Transaction();
            transaction.IBAN = "FI17123456"; 
            transaction.Amount = 700;
            transaction.TimeStamp = DateTime.Now;

            _accountRepository.CreateTransaction(transaction);

            Console.WriteLine("\nTilisiirto onnistui.");
            Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
        }
    }
}