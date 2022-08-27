using CustomerDatalayer.Entities;
using CustomerDatalayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CustomerDatalayer.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public Customer Create(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                    "INSERT INTO [Customers] (FirstName, LastName, PhoneNumber, Email, TotalPurchasesAmount) " +
                    "OUTPUT INSERTED.[CustomerId], INSERTED.[FirstName], INSERTED.[LastName], INSERTED.[PhoneNumber], INSERTED.[Email], INSERTED.[TotalPurchasesAmount] " +
                    "VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @TotalPurchasesAmount)", connection);

                command.Parameters.AddRange(new[] {
                    new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Value = customer.FirstName },
                    new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value = customer.LastName },
                    new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15) { Value = customer.PhoneNumber },
                    new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = customer.Email },
                    new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money) { Value = (object)customer.TotalPurchasesAmount ?? DBNull.Value, IsNullable = true },
                });

                var reader = command.ExecuteReader();
                reader.Read();

                return new Customer(reader);
            }
        }

        public Customer Read(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Customers] WHERE CustomerId = @CustomerId", connection);

                command.Parameters.Add(
                    new SqlParameter("@CustomerId", SqlDbType.Int)
                    {
                        Value = customerId
                    });

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer(reader);
                    }
                }
            }

            return null;
        }

        public int Update(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(
                "UPDATE [Customers] " +
                "SET " +
                    "FirstName = @FirstName, " +
                    "LastName = @LastName, " +
                    "PhoneNumber = @PhoneNumber, " +
                    "Email = @Email, " +
                    "TotalPurchasesAmount = @TotalPurchasesAmount " +
                "WHERE CustomerId = @CustomerId", connection);

                command.Parameters.AddRange(new[] {
                    new SqlParameter("@FirstName", SqlDbType.NVarChar, 50) { Value = customer.FirstName },
                    new SqlParameter("@LastName", SqlDbType.NVarChar, 50) { Value = customer.LastName },
                    new SqlParameter("@PhoneNumber", SqlDbType.NVarChar, 15) { Value = customer.PhoneNumber },
                    new SqlParameter("@Email", SqlDbType.NVarChar, 50) { Value = customer.Email },
                    new SqlParameter("@TotalPurchasesAmount", SqlDbType.Money) { Value = (object)customer.TotalPurchasesAmount ?? DBNull.Value, IsNullable = true },
                    new SqlParameter("@CustomerId", SqlDbType.Int) { Value = customer.Id }
                });

                return command.ExecuteNonQuery();
            }
        }

        public int Delete(int customerId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM [Customers] WHERE CustomerId = @CustomerId", connection);

                command.Parameters.Add(
                    new SqlParameter("@CustomerId", SqlDbType.Int)
                    {
                        Value = customerId
                    });

                return command.ExecuteNonQuery();
            }
        }

        public void DeleteAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                var command = new SqlCommand(
                    "DELETE FROM [CustomerNotes]",
                    connection);
                command.ExecuteNonQuery();
                command = new SqlCommand(
                    "DELETE FROM [Addresses]",
                    connection);
                command.ExecuteNonQuery();
                command = new SqlCommand(
                    "DELETE FROM [Customers]",
                    connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Customer> GetAll()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Customers]", connection);
                SqlDataReader reader = command.ExecuteReader();

                List<Customer> customers = new List<Customer>();
                while (reader.Read())
                    customers.Add(new Customer(reader));

                return customers;
            }
        }
    }
}
