using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaPersonala.Models;

namespace AgendaPersonala.Data
{
    public class AgendaDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public AgendaDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Agenda>().Wait();
        }
        public Task<List<Agenda>> GetNotesAsync()
        {
            return _database.Table<Agenda>().ToListAsync();
        }
        public Task<Agenda> GetNoteAsync(int id)
        {
            return _database.Table<Agenda>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Agenda note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }
        public Task<int> DeleteNoteAsync(Agenda note)
        {
            return _database.DeleteAsync(note);
        }
    }
}
