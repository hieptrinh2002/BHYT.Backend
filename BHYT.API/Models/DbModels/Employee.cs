using System;
using System.Collections.Generic;

namespace BHYT.API.Models.DbModels;

public partial class Employee
{
    public int Id { get; set; }

    public Guid? Guid { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public DateTime? Birthday { get; set; }

    public int? Sex { get; set; }

    public string? Email { get; set; }

    public int? StatusId { get; set; }

    public int? RoleId { get; set; }
}
