using DateTracker.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

            for (int i = 0; i < 50; i++)
            {
                DateList.Add(new DateEntry(Faker.Date.Between(DateTime.Now.AddYears(-100), DateTime.Now)));
            }
        }

        public TimeSpan TimeElapsed(DateTime entry)
        {
            TimeSpan dateDiff = DateTime.Now - entry;
            return dateDiff;
            
        }

        public void AverageDate()
        {
            //DateTime[] dateTimes = DateList
            //DateTime average = dateTimes.Average();

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

        public List<DateEntry> GetSortedDates()
        {
            var output = DateList.OrderBy(x => x.date).ToList();
            return output;
        }

        public DateEntry GetMedianDateEntry()
        {
            var sortedDates = DateList.OrderBy(x => x.date).ToList();
            return sortedDates[sortedDates.Count() / 2];
        }

        public void Clear()
        {
            DateList.Clear();
        }

        private int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                (((end.Month > start.Month) ||
                ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }
    }
}
