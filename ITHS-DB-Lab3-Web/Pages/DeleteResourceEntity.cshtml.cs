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

        public void OnGet(int resourceentityid)
        {
            ResourceEntityData = SqlDatabase.FindResourceEntity(resourceentityid);
        }

        public IActionResult OnPost()
        {
            try
            {
                SqlDatabase.RemoveResourceEntity(ResourceEntityData.Id);
            } catch (SqlException)
            {
                return RedirectToPage("./ResourceEntity");
            }
            return RedirectToPage("./ResourceEntity");
        }
    }
}