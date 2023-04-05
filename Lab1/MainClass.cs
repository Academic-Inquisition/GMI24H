namespace AlgoLab1
{
    internal class MainClass
    {
        public const bool IsDebug = true;
        static void Main(string[] args)
        {
            // Init out List Objects
            ListReferencedBased<Person> p = new ListReferencedBased<Person>();

            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder");
            p.Add(new Person("Benny", 100, "Bagare"));
            p.Add(new Person("Sören", 101, "Snickare"));
            p.Add(new Person("Maria", 102, "Maskinist"));
            p.Add(new Person("Roger", 103, "Universitetadjunkt - Informatik"));
            p.Add(new Person("Johan", 104, "Professor - Mikrodataanalys"), 2);

            Console.WriteLine("");
            Console.WriteLine($"isEmpty? - {p.IsEmpty()}");
            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder");
            Console.WriteLine("");

            Console.WriteLine("Här går texten som fattas!");
            // Implementera: Add för specifikt Index!
            /**
             * Lägger till en Person!
             * index 1-> Namn: Benny, Id: 100, Yrke: Bagare 
             * index 2-> Namn: Alma, Id: 104, Yrke: Advokat 
             * index 3-> Namn: Sören, Id: 101, Yrke: Snickare 
             * index 4-> Namn: Maria, Id: 102, Yrke: Maskinist
             * index 5-> Namn: Roger, Id: 103, Yrke: Universitetsadjunkt - Informatik
             */

            // Implementera/Kolla över: Remove för ett specifikt Index!
            /**
             * Tar bort en Person! 
             * index 1-> Namn: Alma, Id: 104, Yrke: Advokat 
             * index 2-> Namn: Sören, Id: 101, Yrke: Snickare 
             * index 3-> Namn: Maria, Id: 102, Yrke: Maskinist
             * index 4-> Namn: Roger, Id: 103, Yrke: Universitetsadjunkt - Informatik
             */

            Console.WriteLine("");
            Console.WriteLine($"Person på index 2 är: {p.GetValueAtIndex(4)}");
            Console.WriteLine("");

            p.Clear();
            Console.WriteLine($"Kontrollerar: isEmpty? - {p.IsEmpty()}");
            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder");
            Console.WriteLine("");

            Console.WriteLine("Provar att söka ut Person på index 10");
            try
            {
                //p.GetValueAtIndex(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
    }
}