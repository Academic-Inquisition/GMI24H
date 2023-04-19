// See https://aka.ms/new-console-template for more information

namespace Lab2
{

    public class Program
    {
        public static void Main(string[] args)
        {
            HashTableArray<string, Student> map = new HashTableArray<string, Student>();

            Student tim = new Student("Tim", "Stolpe");
            Student simon = new Student("Simon", "Stålnäbb");
            Student markus = new Student("Markus", "Nygren");

            Console.WriteLine(tim.ToString());
            Console.WriteLine(simon.ToString());
            Console.WriteLine(markus.ToString());

            Console.WriteLine();

            
            Console.WriteLine(HashFunction(tim.StudentID, map.Capacity()[0]));
            Console.WriteLine($"Försöker lägga till Tim, Status: {(map.Add(tim.StudentID, tim) ? "Lyckades" : "Misslyckades")}");
            Console.WriteLine(HashFunction(simon.StudentID, map.Capacity()[0]));
            Console.WriteLine($"Försöker lägga till Simon, Status: {(map.Add(simon.StudentID, simon) ? "Lyckades" : "Misslyckades")}");
            Console.WriteLine(HashFunction(markus.StudentID, map.Capacity()[0]));
            Console.WriteLine($"Försöker lägga till Markus, Status: {(map.Add(markus.StudentID, markus) ? "Lyckades" : "Misslyckades")}");

            Console.WriteLine();
            
            Console.WriteLine($"Innehåller kartan Tim?: {tim.StudentID} - {map.ContainsKey(tim.StudentID)}");
            Console.WriteLine($"Innehåller kartan Simon?: {simon.StudentID} - {map.ContainsKey(simon.StudentID)}");
            Console.WriteLine($"Innehåller kartan Markus?: {markus.StudentID} - {map.ContainsKey(markus.StudentID)}");
            Console.WriteLine($"Innehåller kartan Kristin?: h22krsni - {map.ContainsKey("h22krsni")}");

            Console.WriteLine();
            
            Console.WriteLine($"Finns värdet för 'v23timst' i kartan?: {map.ContainsValue(tim)}");
            Console.WriteLine($"Finns värdet för 'v23simst' i kartan?': {map.ContainsValue(simon)}");
            Console.WriteLine($"Finns värdet för 'v23marny' i kartan?': {map.ContainsValue(markus)}");

            Console.WriteLine();

            Console.WriteLine($"Vad har Tim för Info?: {tim.StudentID} - {map.Get(tim.StudentID)}");
            Console.WriteLine($"Vad har Simon för Info?: {simon.StudentID} - {map.Get(simon.StudentID)}");
            Console.WriteLine($"Vad har Markus för Info?: {markus.StudentID} - {map.Get(markus.StudentID)}");

            Console.WriteLine();

            Console.WriteLine($"Storleken av Kartan: [{map.Capacity()[0]}, {map.Capacity()[1]}]");
            Console.WriteLine($"Kartan innehåller {map.TotalCount()} entries!");
            Console.WriteLine(HashFunction(tim.StudentID, map.Capacity()[0]));
            Console.WriteLine($"Tar bort 'v23timst': Status: {(map.Remove(tim.StudentID) ? "Lyckades" : "Misslyckades")}");
            Console.WriteLine($"Kartan innehåller {map.TotalCount()} entries!");
            
            //Console.WriteLine();

            //Console.WriteLine($"{}");
            //Console.WriteLine($"{}");
            //Console.WriteLine($"{}");

            //Console.WriteLine();

            //Console.WriteLine($"{}");
            //Console.WriteLine($"{}");
            //Console.WriteLine($"{}");
            
        }

        public static int HashFunction(string key, int capacity)
        {
            int hash = 5381;
            foreach (char c in key)
            {
                hash = (hash * 33 + c) % capacity;
            }

            return hash;
        }
    }
}