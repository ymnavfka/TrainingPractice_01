using System;

namespace MND_Task_06
{
    class Program
    {
        private static string[,] _dossier = new string[0, 2];
        private static int _size = 0;

        static void Main(string[] args)
        {
            int inputCommand = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Human resource department");
                Console.WriteLine("1 - Add a dossier.");
                Console.WriteLine("2 - Display all dossiers.");
                Console.WriteLine("3 - Delete a dossier.");
                Console.WriteLine("4 - Search by last name.");
                Console.WriteLine("5 - Exit the program.");
                do
                {
                    Console.Write("\nEnter the command number: ");
                    if (!int.TryParse(Console.ReadLine(), out inputCommand))
                        Console.WriteLine("\nYou need to enter numbers!");
                    else if (inputCommand == 1)
                    {
                        AddDossier();
                        break;
                    }
                    else if (inputCommand == 2)
                    {
                        ShowDossiers();
                        break;
                    }
                    else if (inputCommand == 3)
                    {
                        ShowDossiers();
                        RemoveDossier();
                        break;
                    }
                    else if (inputCommand == 4)
                    {
                        Console.WriteLine("Enter your last name to search for: ");
                        string surname = Console.ReadLine();
                        SearchDossier(surname);
                        break;
                    }
                    else if (inputCommand == 5)
                    {
                        Console.WriteLine("Termination of the program..");
                        Environment.Exit(1);
                    }
                    else
                        Console.WriteLine("The entered data is incorrect.");
                } while (true);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }

        private static void AddDossier()
        {
            Console.Write("\nEnter your last name: ");
            string fio = Console.ReadLine() + " ";

            Console.Write("Enter a name: ");
            fio += Console.ReadLine() + " ";

            Console.Write("Enter your middle name: ");
            fio += Console.ReadLine();

            Console.Write("Enter your position: ");
            string post = Console.ReadLine();

            int newsize = _size + 1;

            string[,] cloneDossier = new string[newsize, 2];
            for (int i = 0; i < Math.Min(_size, newsize); i++)
            {
                cloneDossier[i, 0] = _dossier[i, 0];
                cloneDossier[i, 1] = _dossier[i, 1];
            }
            for (int i = _size; i < newsize; i++)
            {
                cloneDossier[i, 0] = "";
                cloneDossier[i, 1] = "";
            }
            _dossier = cloneDossier;
            _size = newsize;

            _dossier[_size - 1, 0] = fio;
            _dossier[_size - 1, 1] = post;
            Console.WriteLine("\nThe dossier was successfully added!");
        }





        private static void ShowDossiers()
        {
            if (_size > 0)
            {
                Console.WriteLine("List of dossiers:");
                for (int i = 0; i < _size; i++) Console.WriteLine($"{i + 1}) {_dossier[i, 0]} - {_dossier[i, 1]}");
            }
            else
            {
                Console.WriteLine("No dossiers available.");
            }
        }



        private static void RemoveDossier()
        {
            int numberOfDossier;
            if (_size > 0)
            {
                do
                {
                    Console.WriteLine("Enter the number to delete the file");

                    if (!int.TryParse(Console.ReadLine(), out numberOfDossier))
                        Console.WriteLine("\nYou need to enter numbers!");
                    else if (--numberOfDossier >= _size || numberOfDossier < 0)
                        Console.WriteLine("Invalid index. Try again!");
                    else
                        break;
                } while (true);

                string[,] cloneDossier = new string[_size - 1, 2];
                int tempNum = 0;
                for (int i = 0; i < _size; i++)
                {
                    if (i != numberOfDossier)
                    {
                        cloneDossier[tempNum, 0] = _dossier[i, 0];
                        cloneDossier[tempNum, 1] = _dossier[i, 1];
                        tempNum++;
                    }
                    else
                    {
                        Console.WriteLine($"Dossier {_dossier[i, 0]} successfully deleted!");
                    }
                }
                _dossier = cloneDossier;
                _size -= 1;
            }
        }





        private static void SearchDossier(string searchForSurname)
        {
            int count = 0;
            for (int i = 0; i < _size; i++)
            {
                if (_dossier[i, 0].IndexOf(searchForSurname) >= 0)
                {
                    Console.WriteLine($"Досье: {i + 1}) {_dossier[i, 0]} - {_dossier[i, 1]}");
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Досье с такой фамилий не найдено!");
            }
        }
    }
}
