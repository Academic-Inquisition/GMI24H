namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinimumArrayValue minValue = new MinimumArrayValue(10);

            Console.WriteLine($"Den aktuella arrayen är: {minValue.GetArray()}.\nDet minsta värdet är {minValue.Run()}");

            // Logic to print all multiplicationtables
            for (int i = 1; i < 10; i++)// make the tables 1-9
                    {
                        Console.WriteLine("\n{0}:ans-tabell\n", i);

                        for (int j = 1; j <= 10; j++) // Multiplý each number 1-10
                        {
                            int k = i * j;
                            Console.WriteLine("{0}x{1}={2}", i, j, k);
                        }
                    }
            
        }
    }
}