using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITHS_DB_Lab3_Web
{
    public class Resource_Entity
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int EntityId { get; set; }
        public string IdentificationNumber { get; set; }
        public int LostByLoanId { get; set; }
    }
}
