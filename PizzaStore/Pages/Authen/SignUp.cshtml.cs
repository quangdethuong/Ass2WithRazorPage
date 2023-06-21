using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaStore.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;

namespace PizzaStore.Pages.Authen
{
    public class SignUpModel : PageModel
    {
        private readonly Assignment2Context _context; // Inject your database context

        public SignUpModel(Assignment2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public string inputUsername { get; set; }

        [BindProperty]
        public string inputFullname { get; set; }

        public string Msg { get; set; }



        [BindProperty]
        public Account user { get; set; }

        public IActionResult OnGet()
        {
            return Page();


        }

        public async Task<IActionResult> OnPostAsync()
        {
            var acId = await _context.Accounts.FirstOrDefaultAsync(p => p.AccountId == user.AccountId);
            if (!ModelState.IsValid)
            {
                Msg = "Signup fail! Account Id Exist";
                return Page();
            }

            _context.Accounts.Add(user);
            await _context.SaveChangesAsync();

            return Redirect("/Index");
        }
    }
}
