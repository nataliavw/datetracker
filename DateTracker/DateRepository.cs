using DateTracker.DTOs;
using System;
using System.Collections.Generic;
using System.IO;

namespace DateTracker
{
    public class DateRepository
    {
        private List<DateEntry> DateList;


        public DateRepository()
        {
            DateList = new List<DateEntry>();
        }

        /// <summary>
        /// Add new item to list.
        /// </summary>
        /// <param name="entry">DateEntry to add to list</param>
        /// <exception cref="ArgumentOutOfRangeException">Dates must be in the past</exception>
        public void Add(DateEntry entry)
        {
            if (entry.date > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException();
            }
            DateList.Add(entry);
        }

        /// <summary>
        /// Returns the current list.
        /// </summary>
        /// <returns></returns>
        public List<DateEntry> GetList()
        {
            return DateList;
        }

        /// <summary>
        /// Populates the repository with 50 randomised entries.
        /// </summary>
        public void Randomise()
        {
            DateList.Clear();

            while (DateList.Count != 50)
            {
                DateList.Add(new DateEntry(Faker.Date.Between(DateTime.Now.AddYears(-100), DateTime.Now)));
            }
        }

        public void TimeElapsed(DateTime entry)
        {
            Console.WriteLine(DateTime.Now - entry);
        }

        /// <summary>
        /// Saves the currently loaded list.
        /// </summary>
        /// <param name="list"></param>
        /// <exception cref="NotImplementedException"></exception>
        public bool SaveList(string filename)
        {
            try
            {
                using (StreamWriter fileOut = new StreamWriter(filename))
                    foreach (var entry in DateList)
                        fileOut.WriteLine(entry);
                return true;
            }
            catch (Exception)
            {
                return false;
            } 
        }

        /// <summary>
        /// (UNIMPLEMENTED) Loads the filed list.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void LoadList()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            DateList.Clear();
        }
    }
}
