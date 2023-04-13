using System;

namespace Lab2
{
    internal class Student
    {
        public string Name { get; set; }
        public int Id { get; }
        public string Occupation { get; }


        public Student(string Name)
        {
            this.Name = Name;
            Id = -1;
            Occupation = "Test";
        }

        public override string ToString()
        {
            return $"Namn: {Name}, Id: {Id}, Yrke: {Occupation}";
        }
    }
}


