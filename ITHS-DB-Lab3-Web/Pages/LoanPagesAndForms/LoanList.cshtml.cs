using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages.LoanPagesAndForms
{
    public class LoanListModel : PageModel
    {
        public IEnumerable<LoanDetails> LoanData { get; set; }
        
        public void OnGet()
        {
            LoanData = SqlDatabase.GetAllLoans();
        }

    }
}