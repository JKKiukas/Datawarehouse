using System;
using BankApp.Models;
using BankApp.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using BankApp.UIModels;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            UIModelAccount uiModelAccount = new UIModelAccount();
            UIModelBank uiModelBank = new UIModelBank();
            UIModelCustomer uiModelCustomer = new UIModelCustomer();
            UIModelTransaction uiModelTransaction = new UIModelTransaction();
            string choice = null;
           
            do
            {
                choice = UserChoice();
                Console.WriteLine();
                switch (choice.ToUpper())
                {
                    case "1":
                        uiModelAccount.CreateAccount();
                        break;

                    case "2":
                        uiModelAccount.ReadAccount();
                        break;

                    case "3":
                        uiModelAccount.ReadAccountWithCustomer();
                        break;

                    case "4":
                        uiModelAccount.DeleteAccount("FI95884501"); //Add IBAN.
                        break;

                    case "5":
                        uiModelAccount.CreateTransaction();
                        break;

                    case "6":
                        uiModelTransaction.ReadTransaction();
                        break;

                    case "7":
                        uiModelBank.CreateBank();
                        break;

                    case "8":
                        uiModelBank.ReadBank();
                        break;

                    case "9":
                        uiModelBank.UpdateBank();
                        break;

                    case "10":
                        uiModelBank.DeleteBank(8); //Add bank's ID number.
                        break;

                    case "11":
                        uiModelCustomer.CreateCustomer();
                        break;

                    case "12":
                        uiModelCustomer.ReadCustomer();
                        break;

                    case "13":
                        uiModelBank.ReadBanksCustomers();
                        break;

                    case "14":
                        uiModelCustomer.UpdateCustomer();
                        break;

                    case "15":
                        uiModelCustomer.DeleteCustomer(16); // Add customer's ID number.
                        break;

                    case "X":
                        Console.WriteLine("\nOhjelma suljetaan.");
                        Console.WriteLine("Paina ENTER-näppäintä jatkaaksesi.");                    
                        break;

                    default:
                        Console.WriteLine("\nVirheellinen syöte.");
                        Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
                        break;
                }
                Console.ReadLine();
                Console.Clear();

            } while (choice.ToUpper() != "X");
        }

        static string UserChoice()
        {
            Console.WriteLine(new string('-', 46));
            Console.WriteLine("|   Syötä valintasi liittyen tileihin.       |");
            Console.WriteLine("|                                            |");
            Console.WriteLine("|         [1] Luo uusi tili                  |");
            Console.WriteLine("|         [2] Lue tiedot tileistä            |");
            Console.WriteLine("|         [3] Lue Asiakkaan tili             |");
            Console.WriteLine("|         [4] Poista tili                    |");
            Console.WriteLine("|         [5] Luo tilisiirto                 |");
            Console.WriteLine("|         [6] Lue tilitapahtumat             |");
            Console.WriteLine(new string('-', 46));

            Console.WriteLine(new string('-', 46));
            Console.WriteLine("|   Syötä valintasi liittyen pankkeihin.     |");
            Console.WriteLine("|                                            |");
            Console.WriteLine("|         [7] Luo uusi pankki                |");
            Console.WriteLine("|         [8] Lue tiedot pankeista           |");
            Console.WriteLine("|         [9] Päivitä pankki                 |");
            Console.WriteLine("|         [10] Poista pankki                 |");
            Console.WriteLine(new string('-', 46));

            Console.WriteLine(new string('-', 46));
            Console.WriteLine("|   Syötä valintasi liittyen asiakkaisiin.   |");
            Console.WriteLine("|                                            |");
            Console.WriteLine("|         [11] Luo uusi asiakas              |");
            Console.WriteLine("|         [12] Lue tiedot asiakkaista        |");
            Console.WriteLine("|         [13] Lue asiakkaan pankki          |");
            Console.WriteLine("|         [14] Päivitä asiakas               |");
            Console.WriteLine("|         [15] Poista asiakas                |");
            Console.WriteLine(new string('-', 46));

            Console.WriteLine(new string('-', 46));
            Console.WriteLine("|         [X] Sulje ohjelma                  |");
            Console.WriteLine(new string('-', 46));
            Console.WriteLine();

            string choice = Console.ReadLine();
            return choice;
        }
    }
}