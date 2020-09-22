using BullsAndCows.Repository.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BullsAndCows.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public string GetIdByEmail (string username)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                connection.Open();
                var query = "SELECT Id FROM AspNetUsers WHERE UserName = @username";

                var data = connection.QueryFirstOrDefault<string>(query, new { username });

                return data;
            }
        }
    }
}
