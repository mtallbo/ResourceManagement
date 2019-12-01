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

        [BindProperty]
        public int ResourceId { get; set; }

        [BindProperty]
        public IEnumerable<Resource> ResourceData { get; set; } 

        public void OnGet()
        {
            ResourceData = SqlDatabase.GetAllResources();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                SqlDatabase.AddResourceEntity(ResourceId, ResourceEntityData.EntityId, ResourceEntityData.IdentificationNumber);
            }
            catch (SqlException)
            {
                return RedirectToPage("./Error");
            }
            return RedirectToPage("./Resources");
        }

    }
}