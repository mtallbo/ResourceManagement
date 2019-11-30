﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ITHS_DB_Lab3_Web.Pages
{
    public class CreateUserModel : PageModel
    {
        
        [BindProperty]
        public User UserData { get; set; }

        [BindProperty]
        public IEnumerable<Roles> RoleData { get; set; }

        [BindProperty]
        public int RoleId { get; set; }

        public void OnGet()
        {
            RoleData = SqlDatabase.GetAllRoles();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            SqlDatabase.AddUser(UserData.FirstName, UserData.LastName, RoleId);
            return RedirectToPage("./Users");
        }
    }
}