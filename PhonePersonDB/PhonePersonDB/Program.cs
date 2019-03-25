using System;
using PhonePersonDB.Repositories;
using PhonePersonDB.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace PhonePersonDB
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository personRepository = new PersonRepository();

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
                        uiModel.ReadPerson();
                        break;

                    case "U":
                        uiModel.UpdatePerson();
                        break;

                    case "D":
                        uiModel.DeletePerson();
                        break;

                    case "E":
                        uiModel.ReadById();
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
            Console.WriteLine("[R] Toiminto lukee henkilöt tietueesta.");
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