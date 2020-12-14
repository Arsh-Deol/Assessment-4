using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Employee_Payee_Tax_Core_Web_App.BusinessLayer;
using Employee_Payee_Tax_Core_Web_App.Models;

namespace Employee_Payee_Tax_Core_Web_App.Pages.Companies
{
    public class CreateModel : PageModel
    {
        private readonly Employee_Payee_Tax_Core_Web_App.Models.Employee_Payee_Tax_DataContext _context;

        public CreateModel(Employee_Payee_Tax_Core_Web_App.Models.Employee_Payee_Tax_DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Company.Add(Company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
