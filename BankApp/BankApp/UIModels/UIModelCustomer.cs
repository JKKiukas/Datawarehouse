using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.UIModels
{
    class UIModelCustomer
    {
        private static readonly CustomerRepository _customerRepository = new CustomerRepository();

        public void ReadCustomer()
        {
            var customer = _customerRepository.Read();

            foreach (var c in customer)
            {
                if(customer == null)
                {
                    Console.WriteLine("Asiakasta ei löytynyt.");
                }

                else
                {
                    Console.WriteLine($"\nAsiakkaan etunimi: {c.Firstname}" +
                                      $"\nAsiakkaan sukunimi: {c.Lastname}" +
                                      $"\nAsiakkaan pankin ID: {c.BankId}");
                }
            }

            Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
        }

        public void CreateCustomer()
        {
            Customer customer = new Customer();
            customer.Firstname = "Kalevi";
            customer.Lastname = "Mäntynen";
            customer.BankId = 1;

            _customerRepository.CreateCustomer(customer);
            Console.WriteLine("Asiakkaan luonti onnistui.");
            Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
        }

        public void DeleteCustomer(int Id)
        {
            _customerRepository.DeleteCustomer(Id);

            Console.WriteLine("\nAsiakas poistettu.");
            Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
        }

        public void UpdateCustomer()
        {
            Customer updateCustomer = _customerRepository.GetCustomer(16); //Add customer's ID number

            if (updateCustomer != null)
            {
                updateCustomer.Firstname = "Urho";
                updateCustomer.Lastname = "Nieminen";
                _customerRepository.UpdateCustomer(16, updateCustomer); //Add customer's ID number.

                Console.WriteLine("Asiakkaan tiedot päivitetty onnistuneesti.");
                Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
            }

            else
            {
                Console.WriteLine("Asiakasta ei voi päivittää, koska asiakasta ei ole olemassa.");
                Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
            }
        }
    }
}