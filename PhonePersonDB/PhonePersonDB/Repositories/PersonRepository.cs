using System;
using System.Collections.Generic;
using System.Text;
using PhonePersonDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace PhonePersonDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PhonepersondbContext _phonepersondbContext = new PhonepersondbContext();

        public void Create(Person person)
        {

            string sql = $"INSERT INTO PERSON (FirstName, LastName) " +
                         $"VALUES ({person.Name}, {person.Age}, {person.Phone})";

            _phonepersondbContext.Person.Add(person);
            _phonepersondbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var deletedPerson = _phonepersondbContext.Person.Find(id);

            if(deletedPerson != null)
            {
                _phonepersondbContext.Person.Remove(deletedPerson);
                _phonepersondbContext.SaveChanges();
                Console.WriteLine("\nTiedot poistettu onnistuneesti!");
            }

            else
            {
                Console.WriteLine();
            }
        }

        public List<Person> Read()
        {
            var persons = _phonepersondbContext.Person.Include(p => p.Phone).ToList();
            return persons;
        }

        public Person GetPersonsAndPhones(int id)
        {
            var persons = _phonepersondbContext.Person.Include(p => p.Phone).Single(p => p.Id == id);
            return persons;
        } 

        public Person Read(long id)
        {
            throw new NotImplementedException();
        }

        public Person ReadById(long id)
        {
            var persons = _phonepersondbContext.Person
                .Include(p => p.Phone)
                .Where(p => p.Id == id)
                .FirstOrDefault();
            return persons;
        }

        public void Update(long id, Person person)
        {
            var isPersonAlive = ReadById(id);

            if (isPersonAlive != null)
            {
                _phonepersondbContext.Update(person);
                _phonepersondbContext.SaveChanges();
                Console.WriteLine("Tiedot päivitetty onnistuneesti!");
                Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
            }

            else
            {
                Console.WriteLine("Tietojen päivitys epäonnistui - henkilöä ei ole olemassa!");
                Console.WriteLine("\nPaina ENTER-näppäintä palataksesi alkuun.");
            }
        }

        internal object ReadById(string v)
        {
            throw new NotImplementedException();
        }
    }
}