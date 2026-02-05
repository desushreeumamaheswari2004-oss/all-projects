// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
class SortingCaseStudy
{
    static void Main()
    {
        // Student Marks (Counting Sort)
        int[] marks = { 78, 95, 45, 62, 78, 90, 45 };
        Console.WriteLine("Original Marks:");
        PrintArray(marks);

        CountingSort(marks, 100);

        Console.WriteLine("\nSorted Marks (Counting Sort):");
        PrintArray(marks);

        // Registration Numbers (Radix Sort)
        int[] regNumbers = { 102345, 984321, 345678, 123456, 567890 };
        Console.WriteLine("\nOriginal Registration Numbers:");
        PrintArray(regNumbers);

        RadixSort(regNumbers);

        Console.WriteLine("\nSorted Registration Numbers (Radix Sort):");
        PrintArray(regNumbers);
        // ---------------- COUNTING SORT ----------------
        static void CountingSort(int[] arr, int maxValue)
        {
            int[] count = new int[maxValue + 1];

            // Step 1: Count occurrences
            foreach (int num in arr)
            {
                count[num]++;
            }

            // Step 2: Rebuild array
            int index = 0;
            for (int i = 0; i <= maxValue; i++)
            {
                while (count[i] > 0)
                {
                    arr[index++] = i;
                    count[i]--;
                }
            }
        }
    }
}