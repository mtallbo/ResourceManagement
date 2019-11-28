using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages
{
    public class CreateResource : PageModel
    {
        [BindProperty]
        public Resource ResourceData { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SqlDatabase.AddResource(ResourceData.CategoryId, ResourceData.Name, ResourceData.Description, ResourceData.Cost);
            return RedirectToPage("./Resources");
        }
    }
}