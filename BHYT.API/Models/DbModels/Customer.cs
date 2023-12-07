using System;
using System.Collections.Generic;

namespace BHYT.API.Models.DbModels;

public partial class Customer
{
    public int Id { get; set; }

    public int UserID { get; set; }

    public string? BankNumber { get; set; }

    public string? Bank { get; set; }
}
