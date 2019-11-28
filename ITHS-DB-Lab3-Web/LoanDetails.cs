using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHS_DB_Lab3_Web
{
    public class LoanDetails : Loan
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DaysLate { get; set; }
        public string ResourceName { get; set; }
        public int TotalSum { get; set; }
    }
}
