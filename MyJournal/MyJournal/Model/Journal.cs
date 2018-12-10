using SQLite;
using System;

namespace MyJournal.Model
{
    public class Journal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string JournalName { get; set; }
        public string JournalDetail { get; set; }
        public DateTime PostDate { get; set; }
    }
}
