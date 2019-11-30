using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages
{
    public class CreateCategoryModel : PageModel
    {
        [BindProperty]
        public Categories Category { get; set; }
        

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SqlDatabase.AddCategory(Category.Category, Category.Identification);
            //try
            //{
            //    SqlDatabase.AddCategory(Category.Category, Category.Identification);
            //}
            //catch (SqlException)
            //{
            //    //Add error message here
            //    return Page();
            //}
            return RedirectToPage("./Resources");
        }
    }
}