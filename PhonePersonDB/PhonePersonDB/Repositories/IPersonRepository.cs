using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PhonePersonDB.Models;

namespace PhonePersonDB.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        void Create(Person person);
        List<Person> Read();
        Person Read(long id);
        Person ReadById(long id);
        void Update(long id, Person person);
        void Delete(long id);
    }
}