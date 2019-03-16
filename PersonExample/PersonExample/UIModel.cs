using PersonExample.Models;
using PersonExample.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonExample
{
    public class UIModel
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        public void ReadByCity()
        {
            var persons = _personRepository.ReadByCity("Juuka");
            foreach (var person in persons)
            {
                Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName} {person.City}");
            }

            Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
        }

        public void ReadById(int id)
        {
            var person = _personRepository.ReadById(id);

            if (person == null)
            {
                Console.WriteLine($"Henkilöä numerolla {id} ei löydy!");
            }

            else
            {
                Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName}");
                Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
            }
        }

        public void CreatePerson()
        {
            Person person = new Person();
            person.FirstName = "James";
            person.LastName = "Bond";
            person.City = "London";
            person.ShoeSize = 42;
            _personRepository.Create(person);
            Console.WriteLine("Henkilön luonti onnistui!");
            Console.WriteLine("Paina ENTER-näppäintä palataksesi alkuun.");
        }

        public void DeleteById(int id)
        {
            ReadById(id);
            _personRepository.Delete(id);
            ReadById(id);
        }

        public void UpdatePerson()
        {
            Person updatePerson = _personRepository.ReadById(5010);
            updatePerson.FirstName = "James";
            updatePerson.DateOfBirth = new DateTime(1960, 1, 13);
            updatePerson.Height = 180;
            updatePerson.EyeColor = "Blue";
            updatePerson.Sex = "Male";
            _personRepository.Update(5010, updatePerson);
        }
    }
}