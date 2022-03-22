using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace Книжный_магазин
{
    public class BookAsyncRepository
    {
        SQLiteAsyncConnection database;

        public BookAsyncRepository(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
        }

        public async Task CreateTable()
        {
            await database.CreateTableAsync<Book>();
        }
        public async Task<List<Book>> GetItemsAsync()
        {
            return await database.Table<Book>().ToListAsync();

        }
        public async Task<Book> GetItemAsync(int id)
        {
            return await database.GetAsync<Book>(id);
        }
        public async Task<int> DeleteItemAsync(Book item)
        {
            return await database.DeleteAsync(item);
        }
        public async Task<int> SaveItemAsync(Book item)
        {
            if (item.Id != 0)
            {
                await database.UpdateAsync(item);
                return item.Id;
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }
    }
}
