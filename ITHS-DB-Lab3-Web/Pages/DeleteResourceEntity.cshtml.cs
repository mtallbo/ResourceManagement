using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages
{
    public class DeleteResourceEntityModel : PageModel
    {
        [BindProperty]
        public Resource_Entity ResourceEntityData { get; set; }

        [BindProperty]
        public int ResourceEntityId { get; set; }

        public void OnGet(int resourceentityid)
        {
            ResourceEntityId = resourceentityid;
            ResourceEntityData = SqlDatabase.FindResourceEntity(resourceentityid);
        }

        public IActionResult OnPost()
        {
            try
            {
                SqlDatabase.RemoveResourceEntity(ResourceEntityId);
            } catch (SqlException)
            {
                TempData["Message"] = "Error deleting entity";
                return Page();
            }
            return RedirectToPage("./ResourceEntity");
        }
    }
}