using System;

namespace MND_Task_02
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;  
            do
            {
                Console.WriteLine("Enter \"exit\" to finish program.");
                ++i;
            } while (Console.ReadLine() != "exit");
            Console.WriteLine("\nTry counter: " + i);
        }
    }
}
