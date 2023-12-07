using System;
using System.Collections.Generic;

namespace BHYT.API.Models.DbModels;

public partial class Employee
{
    public int Id { get; set; }

    public Guid? Guid { get; set; }

    public int UserID { get; set; }

}
