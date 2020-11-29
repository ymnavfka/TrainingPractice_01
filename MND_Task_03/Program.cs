using System;

namespace MND_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int tryCounter = 3;
            const string password = "123";
            const string secretMessage= "Only elite will see this message";
            do
            {
                Console.Write("Enter the password: ");
                if (Console.ReadLine() == password)
                {
                    Console.WriteLine(secretMessage);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong password!" + 
                                      "\nYou have " + --tryCounter + " attempts left\n");
                }
            } while (tryCounter > 0);
        }
    }
}
