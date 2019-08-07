using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Repertoire_PERSO.modele;
using System.Threading.Tasks;

namespace Repertoire_PERSO.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contact>().Wait();
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            return _database.Table<Contact>().OrderBy(p => p.nom).ToListAsync();
        }

        public Task<Contact> GetContactAsync(int id)
        {
            return _database.Table<Contact>()
                            .Where(i => i.ID == id)
                            .OrderBy(p => p.prenom)
                            .FirstOrDefaultAsync();            
        }

        public Task<int> SaveContactAsync(Contact contact)
        {
            if (contact.ID != 0)
            {
                return _database.UpdateAsync(contact);
            }
            else
            {
                return _database.InsertAsync(contact);
            }
        }

        public Task<int> DeleteContactAsync(Contact contact)
        {
            return _database.DeleteAsync(contact);
        }
    }
}
