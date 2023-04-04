using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLab1
{
    internal class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Occupation { get; set; }
        

        public Person(string Name, int Id, string Occupation) 
        {
            this.Name = Name;
            this.Id = Id;
            this.Occupation = Occupation;
        }

        public override string ToString()
        {
            return $"Namn: {Name}, Id: {Id}, Yrke: {Occupation}";
        }
    }
}
