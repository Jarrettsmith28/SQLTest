// <copyright file="Person.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FirstProgram
{
  using System.Data.SqlClient;

  /// <summary>
  /// Person class.
  /// </summary>
  internal class Person
  {
    /// <summary>
    /// gets or sets Id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// gets or sets Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// gets or sets Phone.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// gets or sets Email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// string.
    /// </summary>
    /// <returns>string representation of person.</returns>
    public override string ToString()
    {
      return $"{this.Id} {this.Name} {this.Phone} {this.Email}";
    }
  }
}