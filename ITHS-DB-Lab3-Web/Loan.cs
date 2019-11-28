using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHS_DB_Lab3_Web
{
    public class Loan
    {
        public int Id { get; set; }
        public int LoanerId { get; set; }
        public int BorrowerId { get; set; }
        public int ResourceEntityId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
