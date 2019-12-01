using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages.LoanPagesAndForms
{
    public class ReturnLoanModel : PageModel
    {
        [BindProperty]
        public Loan LoanData { get; set; }

        public void OnGet(int loanid)
        {
            LoanData = SqlDatabase.GetLoan(loanid);
        }

        public IActionResult OnPost()
        {
            try
            {
                SqlDatabase.ReturnLoan(LoanData.Id);
            }
            catch (SqlException)
            {
                return RedirectToPage("./Error");
            }

            return RedirectToPage("./LoanList");
        }
    }
}