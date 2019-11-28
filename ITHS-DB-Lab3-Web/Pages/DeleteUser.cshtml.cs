using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages
{
    public class DeleteUserModel : PageModel
    {
        [BindProperty]
        public User UserData { get; set; }
        
        public void OnGet(int userId)
        {
            UserData = SqlDatabase.FindUser(userId);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                SqlDatabase.RemoveUser(UserData.Id);
            } catch (SqlException)
            {
                return RedirectToPage("./Users");
            }
            return RedirectToPage("./Users");
        }
    }
}