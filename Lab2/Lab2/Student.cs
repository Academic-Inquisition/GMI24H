using System;
using System.Security.Cryptography;

namespace Lab2
{
    internal class Student
    {
        private static int _counter = 0;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; }
        public string StudentID { get; set; }


        public Student(string FirstName, string LastName)
        {
            Id = _counter++;
            this.FirstName = FirstName;
            this.LastName = LastName;
            GetStudentID();
        }

        public override string ToString()
        {
            return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, StudentID: {StudentID}";
        }

        private void GetStudentID()
        {
            string sid = string.Empty;
            DateTime date = DateTime.Now;
            if (date.Month <= 6) sid += "v";
            else sid += "h";
            sid += date.Year.ToString().Substring(2);
            sid += FirstName.ToString().Substring(0, 3) + LastName.ToString().Substring(0, 2);
            StudentID = sid;
        }
    }
}


