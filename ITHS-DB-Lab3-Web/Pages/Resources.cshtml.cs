using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages
{
    public class ResourcesModel : PageModel
    {
        public IEnumerable<Resource> ResourceData;

        public void OnGet()
        {
            ResourceData = SqlDatabase.GetAllResources();
        }
    }
}