using System;

namespace MND_TASK_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int gold = 0;
            int crystalsToBuy = 0;
            const int crystalCost = 15;

            Console.WriteLine($"The rate of crystals to gold - 1 : {crystalCost}");
            bool toContinue = false;
            do
            {
                toContinue = false;
                Console.Write("Enter the amount of your gold: ");

                if (!int.TryParse(Console.ReadLine(), out gold))
                {
                    Console.WriteLine("\nYou need to enter numbers!");
                    toContinue = true;
                }
            } while (toContinue);
            if (gold < 0)
            {
                Console.WriteLine("\nOoh, you're in debt.");
                Console.WriteLine("You don't have any crystals, and you don't have any money for them...");
            }
            else if (gold < crystalCost)
            {
                Console.WriteLine("\nYou don't even have enough money for one crystal.");
                Console.WriteLine($"You have {gold} gold and {crystalsToBuy} crystals.");
            }
            else
            {
                do
                {
                    toContinue = false;
                    Console.WriteLine("How many crystals do you want to buy?");

                    if (!int.TryParse(Console.ReadLine(), out crystalsToBuy))
                    {
                        Console.WriteLine("\nYou need to enter numbers!");
                        toContinue = true;
                    }
                } while (toContinue);


                if (crystalsToBuy * crystalCost > gold)
                {
                    Console.WriteLine("\nYou don't have enough gold");
                    crystalsToBuy = 0;
                    Console.WriteLine($"You have {gold} gold and {crystalsToBuy} crystals.");
                }
                else
                {
                    gold -= crystalsToBuy * crystalCost;
                    Console.WriteLine($"\nYou have {gold} gold and {crystalsToBuy} crystals.");
                }
            }
            Console.ReadKey();
        }
    }
}