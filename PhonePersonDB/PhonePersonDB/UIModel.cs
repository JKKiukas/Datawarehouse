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
            var persons = personRepository.Read();
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Id} {person.Name} {person.Age} {person.Phone}");
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

        public void DeletePerson(int id)
        {
            ReadById(id);
            personRepository.Delete(id);
            ReadById(id);
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

        public void ReadById(int id)
        {
            var persons = personRepository.ReadById(id);
            if (persons == null)
            {
                Console.WriteLine($"Henkilöä numerolla {id} ei löydy!");
            }

            else
            {
                Console.WriteLine($"\nHenkilön ID: {persons.Id}" +
                                  $"\nHenkilön Nimi: {persons.Name}" +
                                  $"\nHenkilön Ikä: {persons.Age}" +
                                  $"\nHenkilön puhelinnumero: {persons.Phone}");
                Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
            }
        }
    }
}