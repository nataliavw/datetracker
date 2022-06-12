using System;

namespace DateTracker.DTOs
{
    public class DateEntry
    {
        public DateEntry(DateTime date)
        {
            this.date = date;
        }
    
        public DateTime date { get; set; }
    }
}