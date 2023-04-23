using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Lab2
{

    public class Student
    {
        // Intern och Global Counter
        private static int _counter = 0;

        // Förnamn
        public string FirstName { get; set; }

        // Efternamn
        public string LastName { get; set; }

        // Det interna numeriska ID:t för Studenten
        public int ID { get; }

        // Det sträng-baserade ID:t för Studenten
        public string StudentID { get; set; }


        // Constructor
        public Student(string FirstName, string LastName)
        {
            ID = _counter++;
            this.FirstName = FirstName;
            this.LastName = LastName;
            StudentID = GetStudentID();
        }

        // ToString implementation för Student
        public override string ToString()
        {
            return $"ID: {ID}, FirstName: {FirstName}, LastName: {LastName}, StudentID: {StudentID}";
        }

        // Metod för att generera det sträng-baserade Student ID:t
        private string GetStudentID()
        {
            string sID = string.Empty; // Empty String
            DateTime date = DateTime.Now; // Hämta datumet
            if (date.Month <= 6) sID += "v"; // Om det är Juni eller Innan så V för Vår-termin
            else sID += "h"; // Om det är Juli eller efter så är det H för Höst-termin
            sID += date.Year.ToString().Substring(2); // Lägg till de sista 2 ifrån året, alltså 2023 -> 23
            sID += FirstName.ToString().Substring(0, 3).ToLower() + LastName.ToString().Substring(0, 2).ToLower(); // Hämta dem första 3 karaktärerna ifrån namnet och dem första 2 ifrån efternamnet.
            return sID; // Returna StudentID:t
        }

    }

}


