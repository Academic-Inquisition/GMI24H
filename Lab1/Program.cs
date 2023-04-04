namespace AlgoLab1
{
    internal class Program
    {
        public const bool IsDebug = false;
        static void Main(string[] args)
        {
            SingleReferencedLinkedList<int> i = new SingleReferencedLinkedList<int>();
            SingleReferencedLinkedList<bool> b = new SingleReferencedLinkedList<bool>();
            SingleReferencedLinkedList<float> f = new SingleReferencedLinkedList<float>();

            i.Add(1);
            i.Add(2);
            i.Add(3); 
            i.Add(4);
            i.Add(5);
            i.AddFirst(0);
            i.RemoveFirst();
            //i.RemoveLast();
            //i.Remove(3);

            b.Add(false);
            b.Add(true);
            b.Add(false);
            b.Add(true);
            b.AddFirst(true);

            f.Add(1.2f);
            f.Add(1.4f);
            f.Add(1.6f);
            f.Add(1.8f);
            f.Add(2.0f);
            f.AddFirst(1.0f);

            Console.WriteLine(i.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(f.ToString());
        }
    }
}