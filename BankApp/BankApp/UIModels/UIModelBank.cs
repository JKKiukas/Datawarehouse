using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.UIModels
{
    class UIModelBank
    {
        private static readonly BankRepository _bankRepository = new BankRepository();

        public void ReadBank()
        {
            var bank = _bankRepository.ReadBank();

            foreach (var b in bank)
            {
                if(bank == null)
                {
                    Console.WriteLine("Pankkia ei löytynyt.");
                }

                else
                {
                    Console.WriteLine($"\nPankin ID: {b.Id}" +
                                      $"\nPankin nimi: {b.Name}" +
                                      $"\nPankin BIC: {b.BIC}");
                }
            }

            Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
        }

        public void ReadBanksCustomers()
        {
            var banksCustomers = _bankRepository.ReadBanksCustomers();

            foreach (var b in banksCustomers)
            {
                if (b == null)
                {
                    Console.WriteLine("Pankin asiakkaita ei löytynyt.");
                }

                else
                {
                    Console.WriteLine($"Henkilö {b.Firstname} {b.Lastname} on pankin {b.Bank.Name} asiakas.");
                }
            }

            Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
        }

        public void CreateBank()
        {
            Bank bank = new Bank();
            bank.Name = "Danske bank";
            bank.BIC = "DABAFIHH";

            _bankRepository.CreateBank(bank);
            Console.WriteLine("Pankin luonti onnistui.");
            Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
        }

        public void DeleteBank(int Id)
        {
            _bankRepository.DeleteBank(Id);

            Console.WriteLine("\nPankki poistettu.");
            Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
        }

        public void UpdateBank()
        {
            Bank updateBank = _bankRepository.GetBank(8); //Add banks ID number.

            if (updateBank != null)
            {
                updateBank.Name = "S-Pankki";
                updateBank.BIC = "SBANFIHH";
                _bankRepository.UpdateBank(8, updateBank); // Add banks ID number.

                Console.WriteLine("Pankki päivitetty onnistuneesti.");
                Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
            }

            else
            {
                Console.WriteLine("Pankkia ei voi päivittää, koska sitä ei ole olemassa.");
                Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
            }
        }
    }
}