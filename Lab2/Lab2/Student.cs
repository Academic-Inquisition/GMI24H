using System;
using System.Security.Cryptography;

namespace Lab2
{
    public class Student
    {
        private static int _counter = 0;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; }
        public string StudentID { get; set; }


        public Student(string FirstName, string LastName)
        {
            ID = _counter++;
            this.FirstName = FirstName;
            this.LastName = LastName;
            StudentID = GetStudentID();
        }

        public override string ToString()
        {
            return $"Id: {ID}, FirstName: {FirstName}, LastName: {LastName}, StudentID: {StudentID}";
        }

        private string GetStudentID()
        {
            string sID = string.Empty;
            DateTime date = DateTime.Now;
            if (date.Month <= 6) sID += "v";
            else sID += "h";
            sID += date.Year.ToString().Substring(2);
            sID += FirstName.ToString().Substring(0, 3).ToLower() + LastName.ToString().Substring(0, 2).ToLower();

            return sID;
        }
    }
}


