using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

    }
}
