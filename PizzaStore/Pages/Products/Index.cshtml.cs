using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaStore.DataAccess;

namespace PizzaStore.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly PizzaStore.DataAccess.Assignment2Context _context;

        public IndexModel(PizzaStore.DataAccess.Assignment2Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();
        }
    }
}
