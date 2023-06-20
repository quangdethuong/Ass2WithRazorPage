using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaStore.Pages.Authen
{
    public class LoginModel : PageModel
    {

        private readonly Assignment2Context _context;

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }


        public LoginModel(Assignment2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Account user { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) // Ensure the submitted form data is valid
            {
                // Query the database to find the user by username
                user = await _context.Accounts.FirstOrDefaultAsync(a => a.UserName == Username);

                if (user != null && VerifyPassword(Password, user.Password) && user.Type == 0)
                {
                    // Authentication successful
                    HttpContext.Session.SetString("username", user.FullName);
                    return Redirect("/Products");
                    
                }
                if (user != null && VerifyPassword(Password, user.Password) && user.Type == 1)
                {
                    return Redirect("/Error");

                }
                
                   
            }

            // Authentication failed or invalid form data
            Msg = "Invalid username or password";
            return Page();
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            return enteredPassword == storedPassword;
        }
    }
}
