using DateTracker.DTOs;
using System;
using System.Collections.Generic;

namespace DateTracker
{
    public class ListClass
    {
        private List<DateEntry> DateList = new List<DateEntry> ();

        /// <summary>
        /// Add new item to list
        /// </summary>
        /// <param name="entry">DateEntry to ad to list</param>
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
        /// Returns the current list
        /// </summary>
        /// <returns></returns>
        public List<DateEntry> GetList()
        {
            return DateList;
        }

        public void SaveList(ListClass list)
        {
            throw new NotImplementedException();
        }

        public void LoadList()
        {
            throw new NotImplementedException();
        }
    }
}
