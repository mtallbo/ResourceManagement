using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ITHS_DB_Lab3_Web.Pages
{
    public class CreateResource : PageModel
    {
        [BindProperty]
        public Resource ResourceData { get; set; }
        
        [BindProperty]
        public IEnumerable<Categories> CategoryData { get; set; }
        
        [BindProperty]
        public int CategoryId { get; set; }

        public void OnGet()
        {
            CategoryData = SqlDatabase.GetAllCategories();
        }


        public IActionResult OnPost()
        {
            

            if (!ModelState.IsValid)
            {
                return Page();
                
            }
            
            SqlDatabase.AddResource(CategoryId, ResourceData.Name, ResourceData.Description, ResourceData.Cost);
            return RedirectToPage("./Resources");
        }
    }
}