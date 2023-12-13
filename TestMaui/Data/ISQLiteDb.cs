
using SQLite;
using System.Reflection;
using TestMaui.Data;
using TestMaui.Forms;

namespace TestMaui.Data
{
    public interface ISQLiteDb
    {
        Task AddContactAsync(ContactM contact);
        Task UpdateContactAsync(ContactM contact);
        Task<List<ContactM>> GetAllContacts();
    }
    
    public class SQLiteDb : ISQLiteDb
    {
        public const SQLite.SQLiteOpenFlags Flags =
           // open the database in read/write mode
           SQLite.SQLiteOpenFlags.ReadWrite |
           // create the database if it doesn't exist
           SQLite.SQLiteOpenFlags.Create |
           // enable multi-threaded database access
           SQLite.SQLiteOpenFlags.SharedCache;

        private SQLiteAsyncConnection _connection;

        public SQLiteDb() 
        {
            var database = Path.Combine(FileSystem.AppDataDirectory,"SQLite.db3");
            _connection = new SQLiteAsyncConnection(database,Flags);
        }

        public async Task AddContactAsync(ContactM contact)
        {
            await _connection.InsertAsync(contact);
        }

        public async Task<List<ContactM>> GetAllContacts()
        {
            var contacts = await _connection.Table<ContactM>().ToListAsync();
            return contacts;
        }

        public async Task UpdateContactAsync(ContactM contact)
        {
            await _connection.UpdateAsync(contact);
        }
    }



}
