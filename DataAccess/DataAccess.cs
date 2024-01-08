using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
 
public class DataAccess
{
    private readonly string connectionString;
 
    public DataAccess(string connectionString)
    {
        this.connectionString = connectionString;
    }
 
    private SqlConnection GetOpenConnection()
    {
        var connection = new SqlConnection(connectionString);
        connection.Open();
        return connection;
    }
 
    public IEnumerable<Customer> GetAllCustomers()
    {
        using var connection = GetOpenConnection();
        using var command = new SqlCommand("SELECT * FROM Customer", connection);
        using var reader = command.ExecuteReader();
 
        var customers = new List<Customer>();
        while (reader.Read())
        {
            customers.Add(new Customer
            {
                UserId = reader.GetGuid(0),
                Username = reader.GetString(1),
                Email = reader.GetString(2),
                FirstName = reader.GetString(3),
                LastName = reader.IsDBNull(4) ? null : reader.GetString(4),
                CreatedOn = reader.GetDateTime(5),
                IsActive = reader.GetBoolean(6)
            });
        }
 
        return customers;
    }
 
    public void CreateCustomer(Customer customer)
    {
        using var connection = GetOpenConnection();
        using var command = new SqlCommand("INSERT INTO Customer VALUES (@UserId, @Username, @Email, @FirstName, @LastName, @CreatedOn, @IsActive)", connection);
 
        command.Parameters.AddWithValue("@UserId", customer.UserId);
        command.Parameters.AddWithValue("@Username", customer.Username);
        command.Parameters.AddWithValue("@Email", customer.Email);
        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
        command.Parameters.AddWithValue("@LastName", (object)customer.LastName ?? DBNull.Value);
        command.Parameters.AddWithValue("@CreatedOn", customer.CreatedOn);
        command.Parameters.AddWithValue("@IsActive", customer.IsActive);
 
        command.ExecuteNonQuery();
    }
 
    public void UpdateCustomer(Customer customer)
    {
        using var connection = GetOpenConnection();
        using var command = new SqlCommand("UPDATE Customer SET Username = @Username, Email = @Email, FirstName = @FirstName, LastName = @LastName, CreatedOn = @CreatedOn, IsActive = @IsActive WHERE UserId = @UserId", connection);
 
        command.Parameters.AddWithValue("@UserId", customer.UserId);
        command.Parameters.AddWithValue("@Username", customer.Username);
        command.Parameters.AddWithValue("@Email", customer.Email);
        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
        command.Parameters.AddWithValue("@LastName", (object)customer.LastName ?? DBNull.Value);
        command.Parameters.AddWithValue("@CreatedOn", customer.CreatedOn);
        command.Parameters.AddWithValue("@IsActive", customer.IsActive);
 
        command.ExecuteNonQuery();
    }
 
    public void DeleteCustomer(Guid userId)
    {
        using var connection = GetOpenConnection();
        using var command = new SqlCommand("DELETE FROM Customer WHERE UserId = @UserId", connection);
 
        command.Parameters.AddWithValue("@UserId", userId);
 
        command.ExecuteNonQuery();
    }
}
