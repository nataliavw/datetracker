using System;

namespace DateTracker.DTOs
{
    public class DateEntry
    {
        public DateTime date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        public DateEntry(DateTime date)
        {
            //Validate DateTime
            this.date = date;
        }
    }

}