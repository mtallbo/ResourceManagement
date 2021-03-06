﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages
{
    public class Resources_Model : PageModel
    {
        public IEnumerable<Resource> ResourceData { get; set; }

        public IEnumerable<ResourceDetails> ResourceDetailsData { get; set; }

        public void OnGet()
        {
            ResourceData = SqlDatabase.GetAllResources();
            ResourceDetailsData = SqlDatabase.GetAllResourceWithCategoryName(); 
        }
    }
}