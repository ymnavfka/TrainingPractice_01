using System;

namespace MND_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
        {
            Random rnd = new Random();

            int bossHealth = 666;
            int playerHealth = 300;
            int playerAttack = 0;

            bool isSmokeScreenUsed = false;
            int cloakAndDaggerCounter = 1;

            int chooseWhoAttack = rnd.Next(1, 3);
            int bossAttack = rnd.Next(1, 5);
            int normalAttack = 30;

            Console.WriteLine("You were born the middle son in the great Talin dynasty." +
                              "While your older brother was being groomed for the throne and your younger brother was being treated with pleasure and care, " +
                              "the average boy was a natural invisibility. " +
                              "You have spent your entire life honing this art, " +
                              "and it was this art that saved you on that fateful day when your people were betrayed and your relatives were killed. " +
                              "No one from the Royal family survived-except for an inconspicuous, clever and cunning shadow in the clouds of smoke. " +
                              "Suddenly attacking and silently cutting the throats of enemies, you escaped from the monarch's domain. " +
                              "Now you, a free-from-the-throne, silent assassin, provide other services. " +
                              "You leave your enemies speechless forever and hone your skills, " +
                              "hoping one day to take revenge on those who killed your family and stripped you of your rights as an heir.");

            Console.WriteLine("\nOne day, walking through the forest at night, you meet a monster. He attacks you sharply. Battle cannot be avoided.");

            Console.WriteLine("\nList of your abilities: " +
                              "\n1. Normal attack - you just hit the monster with a normal hit. " +
                              "\n2. Smoke Screen - You throw a smoke bomb that prevents the monster from using abilities. " +
                              "\n3. Blink Strike - You teleport behind the monster and make a stab in the back. Can be combined with the Cloak and Dagger ability." +
                              "\n4. Healing - You restore yourself 30 HP." +
                              "\n5. Cloak and Dagger - You upgrade your backstabbing skills and increase the damage to the monster in the back by 2 times.");

            Console.WriteLine("\nHit any button if you ready to start...");
            Console.ReadKey();

            while (true)
            {
                Console.WriteLine($"\nYour health: {playerHealth} " +
                                  $"\nThe health of the enemy: {bossHealth}");
                if (chooseWhoAttack == 1)
                {
                    Console.WriteLine("\n\n\nYour turn to attack!");
                    do
                    {
                        Console.WriteLine("Enter 0 if you don't remember your attacks");

                        if (!int.TryParse(Console.ReadLine(), out playerAttack))
                            Console.WriteLine("\nYou need to enter numbers!");
                        else
                            break;
                    } while (true);

                    switch (playerAttack)
                    {
                        case 0:
                            Console.WriteLine("\nList of your abilities:" +
                              "\n1. Normal attack - You just hit the monster with a normal hit." +
                              "\n2. Smoke Screen - You throw a smoke bomb that prevents the monster from using abilities." +
                              "\n3. Blink Strike - You teleport behind the monster and make a stab in the back. Can be combined with the Cloak and Dagger ability." +
                              "\n4. Healing - You restore yourself 30 HP." +
                              "\n5. Cloak and Dagger - You upgrade your backstabbing skills and increase the damage to the monster in the back by 2 times.");
                            break;
                        case 1:
                            Console.Write("You made a normal attack" +
                                          $"\nThe enemy loses {normalAttack} hp");
                            bossHealth -= normalAttack;
                            chooseWhoAttack = 2;
                            break;
                        case 2:
                            Console.WriteLine("You threw a smoke bomb, " +
                                              "the boss will will not be able to use the ability for the next turn.");
                            isSmokeScreenUsed = true;
                            chooseWhoAttack = 2;
                            break;
                        case 3:
                            Console.WriteLine("You moved behind the enemy's back and hit him." +
                                          $"\nThe enemy loses {normalAttack * cloakAndDaggerCounter} hp");
                            bossHealth -= normalAttack * cloakAndDaggerCounter;
                            chooseWhoAttack = 2;
                            break;
                        case 4:
                            playerHealth += 30;
                            Console.WriteLine($"You restored yourself 30 HP. Now you have {playerHealth} HP.");
                            chooseWhoAttack = 2;
                            break;
                        case 5:
                            Console.WriteLine("Your backstabbing skills upgraded and damage the to the monster in the back increased by 2 times.");
                            cloakAndDaggerCounter *= 2;
                            chooseWhoAttack = 2;
                            break;
                        default:
                            playerHealth -= 50;
                            Console.WriteLine($"This ability does not exist, it's time to learn to read, the penalty is 50 HP. Now you have {playerHealth} HP.");
                            chooseWhoAttack = 2;
                            break;
                    }
                }
                else

                {
                    Console.WriteLine("\n\n\nEnemy attack!");
                    switch (bossAttack)
                    {
                        case 1:
                            Console.WriteLine("The boss hit you, his hit was so powerful." + 
                                              "\nYou lose 40 HP.");
                            playerHealth -= 40;
                            break;
                        case 2:
                            if (!isSmokeScreenUsed)
                            {
                                Console.WriteLine("The enemy raged and struck you a series of hits." +
                                                  "\nYou lose 100 HP.");
                                playerHealth -= 60;
                            }
                            else
                            {
                                Console.WriteLine("The enemy tried to use his ability, but he was prevented by your smoke screen");
                                isSmokeScreenUsed = false;
                            }
                            break;
                        case 3:
                            Console.WriteLine("The monster laughs at your weakness and skips a move out of pity.");
                            break;
                        case 4:
                            if (!isSmokeScreenUsed)
                            {
                                bossHealth += 100;
                                Console.WriteLine("The enemy decided to restore his health by 100 HP." +
                                                  $"Now enemy has {bossHealth} HP.");
                            }
                            else
                            {
                                Console.WriteLine("The enemy tried to use his ability, but he was prevented by your smoke screen");
                                isSmokeScreenUsed = false;
                            }
                            break;
                        case 5:
                            if (!isSmokeScreenUsed)
                            {
                                Console.WriteLine("The boss brought down a flaming meteor on you." +
                                                  "\nYou lose 120 HP.");
                                playerHealth -= 120;
                            }
                            else
                            {
                                Console.WriteLine("The enemy tried to use his ability, but he was prevented by your smoke screen");
                                isSmokeScreenUsed = false;
                            }
                            break;
                    }
                    bossAttack = rnd.Next(1, 5);
                    chooseWhoAttack = 1;
                }
                if (bossHealth <= 0)
                {
                    Console.WriteLine("\n\nYou were able to win this difficult battle, congratulations!");
                    break;
                }
                if (playerHealth <= 0)
                {
                    Console.WriteLine("\n\nYou lost this battle, better luck next time.");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}