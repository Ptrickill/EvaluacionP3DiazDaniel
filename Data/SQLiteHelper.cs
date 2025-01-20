using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace EvaluacionP3DiazDaniel.Data
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public SQLiteHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Country>().Wait();
        }

        public Task<int> SaveCountryAsync(Country country)
        {
            return _database.InsertAsync(country);
        }

        public Task<List<Country>> GetCountriesAsync()
        {
            return _database.Table<Country>().ToListAsync();
        }
    }
}
