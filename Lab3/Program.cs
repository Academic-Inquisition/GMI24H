namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MinimumArrayValue minValue = new MinimumArrayValue(10);

            Console.WriteLine($"Den aktuella arrayen är: {minValue.GetArray()}.\nDet minsta värdet är {minValue.Run()}");

            MultiplicationTable.CreateMultiplicationTable();
            
        }
    }
}