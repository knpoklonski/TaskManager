using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TaskManager.BusinessLogic;

namespace TaskManager.DataAccess
{
    public class TaskManagerRepository : ITaskManagerRepository
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["Main"].ConnectionString;

        public IEnumerable<Task> Get(Filter filter)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var whereCondition = filter.State == null
                    ? "WHERE IsDeleted = false"
                    : "WHERE IsDeleted = false AND State=@State";

                var sql = @"SELECT * 
                            FROM [dbo].[Tasks] 
                            {where-condition}
                            LIMIT @Take OFFSET @Skip";

                sql = sql.Replace(@"{where-condition}", whereCondition);

                var sqlParams = new
                {
                    filter.Take,
                    filter.Skip,
                    filter.State
                };

                return connection.Query<Task>(sql, sqlParams);
            }
        }

        public void Add(Task task)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = @"INSERT INTO [dbo].[Tasks]([Name],[Description],[State],[Priority],[TimeToComplete]) 
                            VALUES (@Name,@Description,@State,@Priority,@TimeToComplete)";

                var sqlParam = new
                {
                    task.Name,
                    task.Description,
                    task.State,
                    task.Priority,
                    task.TimeToComplete
                };

                connection.Execute(sql,sqlParam);
                connection.Close();
            }
        }

        public Task GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * 
                            FROM [dbo].[Tasks] 
                            Where Id = @Id AND IsDeleted = false";

                var sqlParam = new {Id = id};

                return connection
                    .Query<Task>(sql, sqlParam)
                    .SingleOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[Tasks]
                            SET IsDeleted = true
                            WHERE Id= @Id";

                var sqlParam = new { Id = id };

                connection.Execute(sql, sqlParam);
                connection.Close();
            }
        }

        public void UpdateState(int id, TaskState state)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var sql = @"UPDATE [dbo].[Tasks]
                            SET State = @State
                            WHERE Id= @Id";

                var sqlParam = new { Id = id, State = state };

                connection.Execute(sql, sqlParam);
                connection.Close();
            }
        }
    }
}