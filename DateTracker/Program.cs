using DateTracker.DTOs;
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
            var dates = new DateRepository();
            DateTime parsedDate;

            Console.WriteLine("Welcome to the Date & Anniversary Tracking program.\n");
            do
            {
                Console.WriteLine(
                    "\nMenu: \n\tPress A to add a date. \n\tPress D to remove a date. \n\tPress T to list all dates." +
                    "\n\tPress R to randomise 50 entries. \n\tPress E to compare a date.  \n\tPress L to load the saved list." +
                    "\n\tPress S to save the current list. \n\tPress Q to exit the program.");
                command = Console.ReadKey(true);

                switch (char.ToLower(command.KeyChar))
                {

                    case 'a':
                        Console.WriteLine("Give a date to add:");
                        if (DateTime.TryParse(Console.ReadLine(), out parsedDate) == true)
                        {
                            var entry = new DateEntry(parsedDate);
                            dates.Add(entry);

                            Console.WriteLine("Date added.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input. Try again from menu.");
                        }
                        break;

                    case 'd':
                        Console.WriteLine("Command Empty.");
                        break;

                    case 't':
                        var dateOutput = dates.GetList();
                        foreach (var date in dates.GetList())
                        {
                            Console.WriteLine(dates.GetList());
                        }
                        break;

                    case 'r':
                        dates.Randomise();
                        Console.WriteLine("List randomised successfully.");
                        break;

                    case 'e':
                        Console.WriteLine("Enter a date to check the time elapsed.");
                        if (DateTime.TryParse(Console.ReadLine(), out parsedDate) == true)
                        {
                            dates.TimeElapsed(parsedDate);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input. Try again from menu.");
                        }
                        break;


                    case 'l':
                        dates.Clear();

                        using (var fileIn = new StreamReader("DateList.txt"))
                        {
                                dates.Add(new DateEntry(DateTime.Now));
                        }
                        Console.WriteLine("List loaded.");
                        break;

                    case 's':
                        if (dates.SaveList("DateList.txt"))
                        {
                            Console.WriteLine("File saved.");
                        }
                        else
                        {
                            Console.WriteLine("File save failed.");
                        }
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
