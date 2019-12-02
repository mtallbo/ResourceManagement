using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ITHS_DB_Lab3_Web.Pages.ResourceEntity
{
    public class ResourceEntityListByIdModel : PageModel
    {
        public Resource ResourceData;
        public IEnumerable<Resource_EntityDetails> ResourceEntityLostAndLoanData;


        public void OnGet(int resourceid)
        {
            //ResourceEntityLostAndLoanData = SqlDatabase.GetAllResourceEntitiesByResource(resourceid);
            ResourceEntityLostAndLoanData = SqlDatabase.GetLostOrLoanedResourceEntities(resourceid);
            ResourceData = SqlDatabase.FindResource(resourceid);
        }
    }
}