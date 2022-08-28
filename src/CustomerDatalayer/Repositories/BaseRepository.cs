using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CustomerDatalayer.Repositories
{
    public abstract class BaseRepository<TEntity>
    {
        public string TableName;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Server=localhost;Database=CustomerLib_Tolstykh;Trusted_Connection=True;");
        }

        private TEntity GetTEntityInstance(SqlDataReader reader)
        {
            return (TEntity)Activator.CreateInstance(typeof(TEntity), reader);
        }

        public List<TEntity> GetAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    $"SELECT * " +
                    $"FROM [{TableName}]", connection);
                SqlDataReader reader = command.ExecuteReader();

                List<TEntity> customers = new List<TEntity>();
                while (reader.Read())
                    customers.Add(GetTEntityInstance(reader));

                return customers;
            }
        }

        public List<TEntity> GetPage(int pageSize, int pageNumber, string orderColumn)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    $"SELECT * " +
                    $"FROM [{TableName}] " +
                    $"ORDER BY {orderColumn} " +
                    $"OFFSET {pageSize * (pageNumber - 1)} ROWS " +
                    $"FETCH FIRST {pageSize} ROWS ONLY", connection);
                SqlDataReader reader = command.ExecuteReader();

                List<TEntity> customers = new List<TEntity>();
                while (reader.Read())
                    customers.Add(GetTEntityInstance(reader));

                return customers;
            }
        }

        public int GetCount()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var command = new SqlCommand(
                    $"SELECT COUNT(*)" +
                    $"FROM [{TableName}]", connection);
                int count = (int)command.ExecuteScalar();

                return count;
            }
        }
    }
}
