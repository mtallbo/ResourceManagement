using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 

namespace ITHS_DB_Lab3_Web.Pages
{
    public class CreateResourceEntityModel : PageModel
    {
        [BindProperty]
        public Resource_Entity ResourceEntityData { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                SqlDatabase.AddResourceEntity(ResourceEntityData.ResourceId, ResourceEntityData.EntityId, ResourceEntityData.IdentificationNumber);
            }
            catch (SqlException)
            {
                //Add error message here
                return Page();
            }
            return RedirectToPage("./Resources");
        }

    }
}