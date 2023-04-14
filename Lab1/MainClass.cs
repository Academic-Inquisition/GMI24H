namespace AlgoLab1
{
    internal class MainClass
    {
        public const bool IsDebug = true;
        static void Main(string[] args)
        {
            ListReferencedBased<Person> p = new ListReferencedBased<Person>();

            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder\n");

            p.Add(new Person("Benny", 100, "Bagare"));
            p.Add(new Person("Sören", 101, "Snickare"));
            p.Add(new Person("Maria", 102, "Maskinist"));
            p.Add(new Person("Roger", 103, "Universitetadjunkt - Informatik"));

            Console.WriteLine($"\nisEmpty? - {p.IsEmpty()}");
            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder\n");

            p.Add(new Person("Johan", 104, "Professor - Mikrodataanalys"), 2);
            
            Console.WriteLine($"\nPerson på index 2 är: {p.GetValueAtIndex(2)}\n");

            p.Remove(2);
            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder\n");
            Console.WriteLine($"Index 1: {p.GetValueAtIndex(1)}");
            Console.WriteLine($"Index 2: {p.GetValueAtIndex(2)}");
            Console.WriteLine($"Index 3: {p.GetValueAtIndex(3)}");
            Console.WriteLine($"Index 4: {p.GetValueAtIndex(4)}");

            Console.WriteLine($"\nPerson på index 2 är: {p.GetValueAtIndex(2)}\n");
            

            p.Clear();
            Console.WriteLine($"Kontrollerar: isEmpty? - {p.IsEmpty()}");
            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder");
            Console.WriteLine("");

            Console.WriteLine("Provar att söka ut Person på index 10");

            try
            {
                p.GetValueAtIndex(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}