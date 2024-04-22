using System;
using System.Diagnostics;

namespace heap_sorting
{

class Program
    {
        public static void Heapify(int[] array, int n, int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] < array[smallest])
                smallest = left;

            if (right < n && array[right] < array[smallest])
                smallest = right;

            if (smallest != i)
            {
                int temp = array[i];
                array[i] = array[smallest];
                array[smallest] = temp;

                Heapify(array, n, smallest);
            }
        }

        public static void HeapSort(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            for (int i = n - 1; i >= 0; i--)
            {

                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                Heapify(array, i, 0);
            }
        }

        public static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[10000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
            }

            Console.WriteLine("Original array:");
            PrintArray(array);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            HeapSort(array);

            stopwatch.Stop();
            Console.WriteLine($"Sorting time: {stopwatch.ElapsedMilliseconds} milliseconds");

            Console.WriteLine("Sorted array in reverse order:");
            PrintArray(array);
        }

        public static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

}

