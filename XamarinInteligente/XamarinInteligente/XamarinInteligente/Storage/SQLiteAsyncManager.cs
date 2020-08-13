using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using XamarinInteligente.Model.Entities;

namespace XamarinInteligente.Storage
{
    public class SQLiteAsyncManager
    {
        private static SQLiteAsyncManager sqliteAsyncManager;
        public static SQLiteAsyncManager Instance
        {
            get
            {
                if(sqliteAsyncManager is null)
                {
                    sqliteAsyncManager = new SQLiteAsyncManager();
                }
                return sqliteAsyncManager;
            }
        }

        private SQLiteAsyncConnection connection;

        public SQLiteAsyncManager()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"db.db3");
            connection = new SQLiteAsyncConnection(path);
            connection.CreateTableAsync<Product>().Wait();
        }

        public async Task SaveValueAsync<T>(T value, bool overrideIfExist)
            where T : IKeyObject, new()
        {
            var item = await connection.FindAsync<T>(value.Id);
            if (item == null)
                await connection.InsertAsync(value);
            else
            {
                if (overrideIfExist)
                    await connection.InsertOrReplaceAsync(value);
                else
                    throw new Exception($"Object with the id {value.Id} already exists");
            }
                
        }

        public async Task DeleteValueAsync<T>(T value)
            where T : IKeyObject, new()
        {
            await connection.DeleteAsync(value);
        }

        public async Task<T> GetItemByidAsync<T>(string id)
            where T : IKeyObject, new()
        {
            T result = default(T);

            result = await connection.FindAsync<T>(id);

            return result;
        }

        public async Task<List<T>> GetAllItems<T>()
            where T : IKeyObject, new()
        {
            List<T> result = new List<T>();
            result = await connection.Table<T>().ToListAsync();
            return result;
        }

        public async Task SaveCatalog<T>(IEnumerable<T> catalog)
            where T : IKeyObject, new()
        {
            await connection.DropTableAsync<T>();
            await connection.CreateTableAsync<T>();
            await connection.InsertAllAsync(catalog);
        }
    }
}
