﻿using DateTracker.DTOs;
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
            DateTime parsedDate;
            var dates = new DateRepository();
            var currentList = dates.GetList();

            Console.WriteLine("Welcome to the Date & Anniversary Tracking program.\n");
            do
            {
                Console.WriteLine(
                    "\n\nMenu: \n\tPress A to add a date. \n\tPress O to sort all dates. \n\tPress T to list all dates." +
                    "\n\tPress R to randomise 50 entries. \n\tPress E to compare a date. \n\tPress V to get the average date. \n\tPress L to load the saved list." +
                    "\n\tPress S to save the current list. \n\tPress Q to exit the program.\n");
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

                    case 'o':
                        var sortedDates = dates.GetSortedDates();
                        Console.WriteLine("Dates successfully reorganised.");
                        for (int i = 0; i < sortedDates.Count; i++)
                        {
                            Console.WriteLine($"{i}: {sortedDates[i].date}");
                        }
                        break;

                    case 'd':
                        Console.WriteLine("Command Empty.");
                        break;

                    case 't':

                        if (dates.GetList().Count == 0)
                        {
                            dates.Randomise();
                        }

                        for (int i = 0; i < currentList.Count; i++)
                        {
                            Console.WriteLine($"{i}: {currentList[i].date}");
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
                            Console.WriteLine($"In format days.hours:minutes:seconds, the time elapsed since the date is: {dates.TimeElapsed(parsedDate)}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input. Try again from menu.");
                        }
                        break;

                    case 'v':
                        Console.WriteLine(dates.GetMedianDateEntry().date);
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
