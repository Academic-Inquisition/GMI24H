using GMI24H_Labb5_Grupp_2.MyAlgorithmLibrary;
using System.Diagnostics;


/// <summary>
/// NOTE: You are by no means obligated to use this project structure. It is just a suggestion. If you want to create
/// your own project from scratch, you are most welcome to do so.
/// 
/// In the Program class you have the Main methods which is the starting point of any program which I am sure that you
/// already are aware of. Normally, it is not appropriate to keep this much code within the Main method so you should consider
/// to move some of the code to other classes and methods. However, the important thing is that you can test your algorithms
/// and that you can show that they work.
/// 
/// Please write comments in your own code for specific test cases or other things that you want to show.
/// It is ok to write your code in English and your comments in Swedish. However, do not mix Enlish and Swedish IN THE CODE.
/// Another way to go ahead with the testing is to write unit tests. It is very much up to you how you decide to 
/// organize your work.
/// 
/// Best of luck! /Elin
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        TimeSpan binarySearchTime = TimeSpan.Zero;
        TimeSpan linearSearchTime = TimeSpan.Zero;
        TimeSpan jumpSearchTime = TimeSpan.Zero;

        TimeSpan bubbleSortTime = TimeSpan.Zero;
        TimeSpan heapSortTime = TimeSpan.Zero;
        TimeSpan insertionSortTime = TimeSpan.Zero;
        TimeSpan quickSortTime = TimeSpan.Zero;
        TimeSpan selectionSortTime = TimeSpan.Zero;

        /**
         * Testnings kod för Sort-Algorithmer går här!
         */
        for (int i = 0; i < 5; i++)
        {
            int[] randomNumbers = new int[1000];
            for (int j = 0; j < randomNumbers.Length; j++)
            {
                randomNumbers[j] = new Random().Next(0, 100);
            }

            switch (i)
            {
                case 0:
                    Bubble_Sort bubbleSort = new Bubble_Sort();
                    Stopwatch bubbleSortStopwatch = new Stopwatch();
                    bubbleSortStopwatch.Start();
                    bubbleSort.Sort(randomNumbers);
                    bubbleSortStopwatch.Stop();
                    bubbleSortTime = bubbleSortStopwatch.Elapsed;
                    break;
                case 1:
                    Heap_Sort heapSort = new Heap_Sort();
                    Stopwatch heapSortStopwatch = new Stopwatch();
                    heapSortStopwatch.Start();
                    heapSort.Sort(randomNumbers);
                    heapSortStopwatch.Stop();
                    heapSortTime = heapSortStopwatch.Elapsed;

                    break;
                case 2:
                    Insertion_Sort insertionSort = new Insertion_Sort();
                    Stopwatch insertionSortStopwatch = new Stopwatch();
                    insertionSortStopwatch.Start();
                    insertionSort.Sort(randomNumbers);
                    insertionSortStopwatch.Stop();
                    insertionSortTime = insertionSortStopwatch.Elapsed;

                    break;
                case 3:
                    Quick_Sort quickSort = new Quick_Sort();
                    Stopwatch quickSortStopwatch = new Stopwatch();
                    quickSortStopwatch.Start();
                    quickSort.Sort(randomNumbers);
                    quickSortStopwatch.Stop();
                    quickSortTime = quickSortStopwatch.Elapsed;

                    break;
                case 4:
                    Selection_Sort selectionSort = new Selection_Sort();
                    Stopwatch selectionSortStopwatch = new Stopwatch();
                    selectionSortStopwatch.Start();
                    selectionSort.Sort(randomNumbers);
                    selectionSortStopwatch.Stop();
                    selectionSortTime = selectionSortStopwatch.Elapsed;
                    break;
            }
        }

        /**
         * Redovisnings kod för Sort-Algorithmer går här!
         */
        Console.WriteLine("Sort Timings:");
        if (bubbleSortTime != null)
            Console.WriteLine($"    Bubble Sort Time:    {bubbleSortTime}");
        if (heapSortTime != null)
            Console.WriteLine($"    Heap Sort Time:      {heapSortTime}");
        if (insertionSortTime != null)
            Console.WriteLine($"    Insertion Sort Time: {insertionSortTime}");
        if (quickSortTime != null)
            Console.WriteLine($"    Quick Sort Time:     {quickSortTime}");
        if (selectionSortTime != null)
            Console.WriteLine($"    Selection Sort Time: {selectionSortTime}");
        
        /**
         * Testnings kod för Search-Algorithmer går här!
         */
        int[] jsArray = { 0, 1, 347, 2, 3, 4, 6, 67, 28, 34, 467, 34, 38, 69};
        Jump_Search js = new Jump_Search();
        Stopwatch jumpSearchStopwatch = new Stopwatch();
        jumpSearchStopwatch.Start();
        int found = js.Search(jsArray, 69);
        if (found != 11) throw new Exception("Jump Search failed!");
        jumpSearchStopwatch.Stop();
        jumpSearchTime = jumpSearchStopwatch.Elapsed;

        /**
         * Redovisnings kod för Sort-Algorithmer går här!
         */
        Console.WriteLine("Search Timings:");
        if (binarySearchTime != null)
            Console.WriteLine($"    Binary Search Time:  {binarySearchTime}");
        if (linearSearchTime != null)
            Console.WriteLine($"    Linear Search Time:  {linearSearchTime}");
        if (jumpSearchTime != null)
            Console.WriteLine($"    Jump Search Time:    {jumpSearchTime}");
    }



}