namespace GMI24H_Labb5_Grupp_2.MyAlgorithmLibrary
{/// <summary>
/// This interface is used to define which algorithms that can be implemented in the Sorter class
/// </summary>
    internal interface ISorter
    {

        void BubbleSort(int[] arr);
        void InsertionSort(int[] arr);
        void SelectionSort(int[] arr);
        
        void HeapSort(int[] arr);
        void QuickSort(int[] arr, int low, int high);

    }
}