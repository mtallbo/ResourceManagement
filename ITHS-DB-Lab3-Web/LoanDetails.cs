using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHS_DB_Lab3_Web
{
    public class LoanDetails : Loan
    {
        public string FullNameBorrower { get; set; } 
        public string FullNameLoaner { get; set; }
    }
}
