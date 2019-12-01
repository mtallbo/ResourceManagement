using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages
{
    public class Delete_ResourceModel : PageModel
    {
        [BindProperty]
        public Resource ResourceData { get; set; }
        
        public void OnGet(int resourceid)
        {
            ResourceData = SqlDatabase.FindResource(resourceid);
        }

        public IActionResult OnPost()
        {
            try
            {
                SqlDatabase.RemoveResource(ResourceData.Id);
            } catch (SqlException)
            {
                return RedirectToPage("./Resources");
            }
            return RedirectToPage("./Resources");
        }
    }
}