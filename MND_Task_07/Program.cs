using System;

namespace MND_Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 0;
            do
            {
                Console.Write("Enter the size of array: ");

                if (!int.TryParse(Console.ReadLine(), out arraySize))
                    Console.WriteLine("\nYou need to enter numbers!");
                else if (arraySize <= 0)
                    Console.WriteLine("The array size cannot be negative or equal to zero.");
                else
                    break;
            } while (true);

            int[] array = new int[arraySize];
            Random rnd = new Random();
            for (int i = 0; i < arraySize; i++) array[i] = rnd.Next(0, 100);

            Console.WriteLine("\nOriginal array:");
            for (int i = 0; i < arraySize; i++) Console.Write(array[i] + " ");
            Console.WriteLine("\n\nThe resulting array:");
            Shuffle(array);
            for (int i = 0; i < arraySize; i++) Console.Write(array[i] + " ");
            Console.ReadKey();
        }
        static void Shuffle(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int rndSelect = rnd.Next(0, i + 1);
                int j = array[rndSelect];
                array[rndSelect] = array[i];
                array[i] = j;
            }
        }
    }
}