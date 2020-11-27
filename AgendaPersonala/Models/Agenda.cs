using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AgendaPersonala.Models
{
    public class Agenda
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

    }
}
