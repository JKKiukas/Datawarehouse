using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PhonePersonDB.Models
{
    public partial class Person
    {
        public Person()
        {
            Phone = new HashSet<Phone>();
        }

        public Person(string name, short age)
        {
            Name = name;
            Age = Age;
            Phone = new HashSet<Phone>();
        }

        public Person(string name, short age, ICollection<Phone> phones)
        {
            Name = name;
            Age = Age;
            Phone = phones;
        }

        public long Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public short? Age { get; set; }

        [InverseProperty("Person")]
        public virtual ICollection<Phone> Phone { get; set; }
    }
}