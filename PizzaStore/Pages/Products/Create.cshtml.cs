using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using PizzaStore.DataAccess;

namespace PizzaStore.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly PizzaStore.DataAccess.Assignment2Context _context;

        public CreateModel(PizzaStore.DataAccess.Assignment2Context context)
        {
            _context = context;
        }

        public string Msg { get; set; }


        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            return Page();
        }

        [BindProperty]
        public Product Productss { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var pro = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == Productss.ProductId);
           
            if (!ModelState.IsValid || pro != null)
            {
                Msg = "Create fail! ProductId Exist";

                return Page();
            }

            else
            {
             
            
                    _context.Add(Productss);
                    await _context.SaveChangesAsync();
               
            }
            return Redirect("/Index");


        }
    }
}
