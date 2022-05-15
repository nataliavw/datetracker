using System;
using System.Collections.Generic;
using System.IO;


namespace DateTracker
{
    partial class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo command;
            var list = new Dictionary<int, string>();
            int nextFree;
            string line;

            Console.WriteLine("Welcome to the Date & Anniversary Tracking program.\n");
            do
            {
                Console.WriteLine(
                    "\nMenu: \n\tPress A to add a date. \n\tPress R to remove a date. \n\tPress T to list all dates." +
                    " \n\tPress L to load the saved list. \n\tPress S to save the current list. \n\tPress Q to exit the program.");
                command = Console.ReadKey(true);

                switch (char.ToLower(command.KeyChar))
                {

                    case 'a':

                        nextFree = 0;
                        Console.WriteLine("Give a date to add:");

                        do
                        {
                            nextFree++;

                        } while (list.ContainsKey(nextFree));

                        list.Add(nextFree, Console.ReadLine());


                        Console.WriteLine("Date added.");
                        break;

                    case 'r':
                        Console.WriteLine("Command Empty.");
                        break;

                    case 't':
                        Console.WriteLine("Command Empty.");
                        break;

                    case 'l':
                        nextFree = 1;

                        list.Clear();

                        using (var fileIn = new StreamReader("DateList.txt"))
                        {
                            while ((line = fileIn.ReadLine()) != null)
                            {
                                list.Add(nextFree, line);
                                nextFree++;
                            }
                        }
                        Console.WriteLine("List loaded.");
                        break;

                    case 's':
                        using (StreamWriter fileOut = new StreamWriter("DateList.txt"))
                            foreach (var entry in list)
                                fileOut.WriteLine(entry.Value);
                        Console.WriteLine("File saved.");

                        break;

                    case 'q':
                        Console.WriteLine("Quitting");
                        break;

                    default:
                        Console.WriteLine("Command not recognised.");
                        break;
                }

            } while (command.KeyChar != 'q');

#if DEBUG
            Console.WriteLine("\n\nPress enter to close");
            Console.ReadKey();
#endif
        }
    }
}
