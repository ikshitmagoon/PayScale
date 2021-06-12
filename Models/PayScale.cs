using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebAppCoreAzure.Models
{
    public partial class PayScale
    {
        public int EmployeeId { get; set; }
        public string PayBand { get; set; }
        public double BasicSalary { get; set; }
        public double? Hra { get; set; }
        public double? Da { get; set; }
        public double? Ta { get; set; }
        public double? Tds { get; set; }
        public double? NetSalary { get; set; }
        public double? InHandSalary { get; set; }
    }
}
