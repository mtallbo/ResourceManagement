using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages.LoanForm
{
    public class LoanEntityModel : PageModel
    {
        [BindProperty]
        public Loan LoanData { get; set; }

        Resource_Entity ResourceData { get; set; }
        public int EntityId { get; set; }
        [BindProperty]
        public IEnumerable<User> UserData { get; set; }
        [BindProperty]
        public DateTime FormStartDate { get; set; }
        [BindProperty]
        public DateTime FormEndDate { get; set; }
        [BindProperty]
        public int LoanderId { get; set; }
        [BindProperty]
        public int BorrowerId { get; set; }

        public void OnGet(int resourceentityid)
        {
            EntityId = resourceentityid;
            ResourceData = SqlDatabase.FindResourceEntity(resourceentityid);
            UserData = SqlDatabase.GetAllUsers();
            
        }

        public IActionResult OnPost(int resourceentityid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SqlDatabase.AddLoanEntity(LoanderId, BorrowerId, resourceentityid, FormStartDate.ToString("yyyy-MM-dd"), FormEndDate.ToString("yyyy-MM-dd"));
            return RedirectToPage("../Resources");
        }
    }
}