using PhonePersonDB.Models;
using PhonePersonDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhonePersonDB
{
    public class UIModel
    {
        private static readonly PersonRepository personRepository = new PersonRepository();

        public void ReadPerson()
        {
            var people = personRepository.Read();

            foreach (var person in people)
            {
                if (people == null)
                {
                    Console.WriteLine($"Henkilöä ei löydy!");
                }

                else
                {
                    Console.WriteLine($"\nHenkilön ID: {person.Id}" +
                                      $"\nHenkilön Nimi: {person.Name}" +
                                      $"\nHenkilön Ikä: {person.Age}" +
                                      $"\nHenkilön puhelinnumero:");

                    foreach (var p in person.Phone)
                    {
                        Console.WriteLine($"{p.Type} {p.Number}");
                    }

                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
        }

        public void CreatePerson()
        {
            Person person = new Person();
            person.Name = "Pelle Peloton";
            person.Age = 60;
            person.Phone = new List<Phone>

            {
                new Phone{Type = "Home", Number = "0101010"},
                new Phone{Type = "Work", Number = "0202020"}
            };

            personRepository.Create(person);
            Console.WriteLine("Henkilön luonti onnistui!");
            Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
        }

        public void DeletePerson()
        {
            Console.WriteLine("\nSyötä henkilön ID, jonka tiedot haluat poistaa.");
            var userInput = int.Parse(Console.ReadLine());
            personRepository.Delete(userInput);

            object persons = null;
            if (persons == null)
            {
                Console.WriteLine($"Henkilöä ID:llä {userInput} ei löydy!");
                Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
            }

            else
            {
                Console.WriteLine("Tiedot poistettu onnistuneesti.");
                Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
            }
        }

        public void UpdatePerson()
        {
            Person updatePerson = personRepository.ReadById(11);
            updatePerson.Name = "Pelle Peloton";
            updatePerson.Age = 65;
            updatePerson.Phone = new List<Phone>

            {
                new Phone { Type = "Home", Number = "0303030" }
            };

            personRepository.Update(11, updatePerson);
        }

        public void ReadById()
        {

            Console.WriteLine("\nSyötä henkilön ID, jonka tiedot haluat nähdä.");
            var userInput = int.Parse(Console.ReadLine());
            var persons = personRepository.ReadById(userInput);

            if (persons == null)
            {
                Console.WriteLine($"Henkilöä ID:llä {userInput} ei löydy!");
            }

            else
            {
                Console.WriteLine($"\nHenkilön ID: {persons.Id}" +
                                  $"\nHenkilön Nimi: {persons.Name}" +
                                  $"\nHenkilön Ikä: {persons.Age}" +
                                  $"\nHenkilön puhelinnumero:");

                foreach (var p in persons.Phone)
                {
                    Console.Write($"{p.Type} {p.Number}");
                }

                Console.WriteLine();
                Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
            }
        }
    }
}