using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CuposApp
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _database.Table<User>().Where(i => i.Email == email).FirstAsync();
        }

        public Task<User> GetUserByPassAsync(string passw)
        {
            return _database.Table<User>().Where(i => i.Password == passw).FirstAsync();
        }

        public Task<User> GetUserByLoginAsync(User user)
        {
            return _database.Table<User>().Where(i => i == user).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (!GetUserByEmailAsync(user.Email).IsFaulted)
            {
                return _database.InsertAsync(user);
            }
            else
            {
                return _database.UpdateAsync(user);
            }
            
        }

        public Task<int> UpdateUserAsync(User user)
        {
            return _database.UpdateAsync(user);
        }
    }
}
