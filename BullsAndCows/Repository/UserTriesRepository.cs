using BullsAndCows.Repository.Interfaces;
using BullsAndCows.Repository.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BullsAndCows.Repository
{
    public class UserTriesRepository : IUserTriesRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserTriesRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<UserTries> GetAll()
        {
            using(var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                connection.Open();
                var query = @"SELECT au.UserName, ut.Tries FROM UserTries AS ut
                              FULL OUTER JOIN AspNetUsers as au
                              ON ut.UserId = au.Id
                              WHERE ut.Tries > 0
                              ORDER BY ut.Tries asc";

                var data =  connection.Query<UserTries>(query).ToList();

                return data;
            }         
        }

        public void Insert(string userId, int tries)
        {
           using(var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction()) {

                    try
                    {

                        var query = @"UPDATE UserTries SET Tries = @tries WHERE UserId = @userId;
                                       IF @@ROWCOUNT = 0
                                       BEGIN
                                         INSERT UserTries(UserId, Tries) VALUES (@userId, @tries)
                                       END";

                        connection.Execute(query, new { userId, tries }, transaction);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                    finally {
                        connection.Close();
                    }
                };   
              
            }
        }
    }
}
