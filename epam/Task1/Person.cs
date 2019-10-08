using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam.Task1
{
    struct Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public string IsOlderThen(int n)
        {
            return (Age > n) ? $"{Name} {Surname} is older than {n}" : $"{Name} {Surname} is younger than {n}";
        }
    }
}
