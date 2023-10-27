
using SQLite;
using System.Reflection;
using TestMaui.Data;

namespace TestMaui.Data
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
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

        public SQLiteAsyncConnection GetConnection()
        {
            var database = Path.Combine(FileSystem.AppDataDirectory,"SQLite.db3");
            return new SQLiteAsyncConnection(database,Flags);
        }
    }



}
