using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class CrudOperations
{
    private readonly string _connectionString;

    public CrudOperations(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreatePerson(string firstName, string lastName)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var cmd = new SqlCommand("INSERT INTO People (FirstName, LastName) VALUES (@FirstName, @LastName)", connection);
        cmd.Parameters.AddWithValue("@FirstName", firstName);
        cmd.Parameters.AddWithValue("@LastName", lastName);
        cmd.ExecuteNonQuery();
    }

    public IEnumerable<(int Id, string FirstName, string LastName)> ReadPeople()
    {
        var results = new List<(int, string, string)>();
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var cmd = new SqlCommand("SELECT Id, FirstName, LastName FROM People", connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            results.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
        }
        return results;
    }

    public void UpdatePerson(int id, string firstName, string lastName)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var cmd = new SqlCommand("UPDATE People SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id", connection);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.Parameters.AddWithValue("@FirstName", firstName);
        cmd.Parameters.AddWithValue("@LastName", lastName);
        cmd.ExecuteNonQuery();
    }

    public void DeletePerson(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var cmd = new SqlCommand("DELETE FROM People WHERE Id = @Id", connection);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
    }
}
