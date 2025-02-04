﻿using PersonExample.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonExample.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        void Create(Person person);
        List<Person> ReadByCity(string city);
        Person ReadById(long id);
        void Update(long id, Person person);
        void Delete(long id);
    }
}