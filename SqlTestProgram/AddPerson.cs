// <copyright file="AddPerson.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FirstProgram
{
  using System.Data;
  using System.Data.SqlClient;

  /// <summary>
  /// AddPerson class.
  /// </summary>
  internal class AddPerson
  {
    /// <summary>
    /// gets or sets name property.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// gets or sets phone property.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// gets or sets email property.
    /// </summary>
    public string? Email { get; set; }
  }
}