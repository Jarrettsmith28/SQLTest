// <copyright file="Crud.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FirstProgram
{
  using System.Data;
  using System.Data.SqlClient;

  /// <summary>
  /// Crud class.
  /// </summary>
  internal class Crud
  {
    /// <summary>
    /// Create method.
    /// </summary>
    /// <param name="person">person.</param>
    public static void Create(AddPerson person)
    {
      using (SqlConnection con = CreateConnection())
      {
        string queryString = $"INSERT INTO People( Name, Phone, Email) VALUES('{person.Name}', '{person.Phone}', '{person.Email}')";
        using (SqlCommand cmd = new SqlCommand(queryString, con))
        {
          cmd.ExecuteNonQuery();
        }
      }
    }

    /// <summary>
    /// Read method.
    /// </summary>
    /// <param name="id">id.</param>
    /// <returns>person.</returns>
    public static Person Read(int id)
    {
      Person person = new Person();

      using SqlConnection con = CreateConnection();
      string queryString = $"SELECT * FROM People WHERE PersonId = {id}";
      using SqlCommand cmd = new SqlCommand(queryString, con);
      using SqlDataReader reader = cmd.ExecuteReader();
      if (reader.Read())
      {
        return AutoReader(reader);
      }

      return person;
    }

    /// <summary>
    /// Read all method.
    /// </summary>
    /// <returns>peopleList.</returns>
    public static List<Person> ReadAll()
    {
      var peopleList = new List<Person>();
      string queryString = $"SELECT * FROM People";

      using SqlConnection con = CreateConnection();
      using SqlCommand cmd = new SqlCommand(queryString, con);
      using SqlDataReader reader = cmd.ExecuteReader();
      while (reader.Read())
      {
        Person person = AutoReader(reader);
        peopleList.Add(person);
      }

      return peopleList;
    }

    /// <summary>
    /// Update method.
    /// </summary>
    /// <param name="person">person.</param>
    public static void Update(Person person)
    {
      SqlConnection con = CreateConnection();
      string queryString = $"UPDATE People SET name = '{person.Name}', Phone = '{person.Phone}', Email = '{person.Email}' WHERE PersonId = '{person.Id}'";
      SqlCommand cmd = new SqlCommand(queryString, con);
      cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Delete method.
    /// </summary>
    /// <param name="id">id.</param>
    public static void Delete(int id)
    {
      SqlConnection con = CreateConnection();
      string queryString = $"DELETE FROM People WHERE PersonId = {id}";
      SqlCommand cmd = new SqlCommand(queryString, con);
      cmd.ExecuteNonQuery();
    }

    private static SqlConnection CreateConnection()
    {
      string conString = "Data Source=L6038;Initial Catalog=myTestDatabase;" +
        "Integrated Security=true";
      SqlConnection conn = new SqlConnection(conString);
      conn.Open();
      return conn;
    }

    /// <summary>
    /// AutoReader Method.
    /// </summary>
    /// <param name="reader">reade.</param>
    /// <returns>person.</returns>
    private static Person AutoReader(SqlDataReader reader)
    {
      Person person = new Person();
      person.Id = reader.GetInt32("PersonId");
      person.Phone = reader.GetString("Phone");
      person.Email = reader.GetString("Email");
      person.Name = reader.GetString("Name");
      return person;
    }
  }
}