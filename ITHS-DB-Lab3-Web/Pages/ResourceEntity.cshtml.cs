using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


/* THIS PAGE IS NOT IN USE */

namespace ITHS_DB_Lab3_Web.Pages
{
    public class ResourceEntityModel : PageModel
    {
        
        public IEnumerable<Resource_Entity> EntityData;

        
        public void OnGet()
        {
            EntityData = SqlDatabase.GetAllResourceEntity();
        }

    }
}