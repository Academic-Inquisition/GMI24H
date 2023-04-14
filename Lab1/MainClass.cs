namespace AlgoLab1
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            ListReferencedBased<Person> p = new ListReferencedBased<Person>();

            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder\n");
            // create people by filling in name, id and occupation
            p.Add(new Person("Benny", 100, "Bagare"));
            p.Add(new Person("Sören", 101, "Snickare"));
            p.Add(new Person("Maria", 102, "Maskinist"));
            p.Add(new Person("Roger", 103, "Universitetadjunkt - Informatik"));
            // returns a bool if true or false and the the list´s length
            Console.WriteLine($"\nisEmpty? - {p.IsEmpty()}");
            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder\n");
            // write the person on index 2 to compare later
            p.Add(new Person("Johan", 104, "Professor - Mikrodataanalys"), 2);
            Console.WriteLine($"Person på index 2 är: {p.GetValueAtIndex(2)}\n");
            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder\n");
            // romove on index 2 and print the list again
            p.Remove(2);
            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder\n");
            Console.WriteLine($"Index 1: {p.GetValueAtIndex(1)}");
            Console.WriteLine($"Index 2: {p.GetValueAtIndex(2)}");
            Console.WriteLine($"Index 3: {p.GetValueAtIndex(3)}");
            Console.WriteLine($"Index 4: {p.GetValueAtIndex(4)}");
            // doublecheck so values match
            Console.WriteLine($"\nPerson på index 2 är: {p.GetValueAtIndex(2)}\n");
            
            // set the list size to 0 (empty)
            p.Clear();
            Console.WriteLine($"Kontrollerar: isEmpty? - {p.IsEmpty()}");
            Console.WriteLine($"Listan innehåller nu: {p.Length()} noder\n");
            // testing out of range index value
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