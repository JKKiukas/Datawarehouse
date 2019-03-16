using System;
using System.Runtime.InteropServices;
using PersonExample.Repositories;
using PersonExample.Models;

namespace PersonExample
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        static void Main(string[] args)
        {
            UIModel uiModel = new UIModel();
            string choice = null;

            do
            {
                choice = UserChoice();
                Console.WriteLine();
                switch (choice.ToUpper())
                {
                    case "C":
                        uiModel.CreatePerson();
                        break;

                    case "R":
                        uiModel.ReadByCity();
                        break;

                    case "U":
                        uiModel.UpdatePerson();
                        break;

                    case "D":
                        uiModel.DeleteById(5011);
                        break;

                    case "E":                        
                        uiModel.ReadById(888);
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
            Console.WriteLine("Syötä valintasi.");
            Console.WriteLine("\n[C] Toiminto lisää tietokantaan uuden tietueen.");
            Console.WriteLine("[R] Toiminto lukee tietyn kaupungin henkilöt.");
            Console.WriteLine("[U] Toiminto päivitää tiettyn henkilön tiedot.");
            Console.WriteLine("[D] Toiminto poistaa yhden henkilön tiedot.");
            Console.WriteLine("[E] Toiminto lukee tietyn ID:n omaavan henkilö.");
            Console.WriteLine("[X] Toiminto sulkee ohjelman.");
            Console.WriteLine();

            string choice = Console.ReadLine();
            return choice;
        }
    }
}