using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using AzureMySQLWebAPI.Models;

namespace AzureMySQLWebAPI.Data
{
    public class ItemRepository
    {
        private readonly string _connectionString;

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.QueryAsync<Item>("SELECT * FROM Items");
            }
        }

        // Add method to retrieve a single item by id
        public async Task<Item> GetItemByIdAsync(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return await db.QueryFirstOrDefaultAsync<Item>("SELECT * FROM Items WHERE Id = @Id", new { Id = id });
            }
        }

        // Add method to insert a new item
        public async Task<int> AddItemAsync(Item item)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Items (Name) VALUES (@Name); SELECT LAST_INSERT_ID();";
                return await db.ExecuteScalarAsync<int>(sql, item);
            }
        }

        // Add method to update an existing item
        public async Task UpdateItemAsync(Item item)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var sql = "UPDATE Items SET Name = @Name WHERE Id = @Id";
                await db.ExecuteAsync(sql, item);
            }
        }

        // Add method to delete an item
        public async Task DeleteItemAsync(int id)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                await db.ExecuteAsync("DELETE FROM Items WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task AddItemUsingStoredProcedureAsync(Item item)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("itemName", item.Name, DbType.String);

                await db.ExecuteAsync("AddNewItem", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
