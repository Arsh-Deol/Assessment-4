using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Employee_Payee_Tax_Core_Web_App.BusinessLayer;
using Employee_Payee_Tax_Core_Web_App.Models;

namespace Employee_Payee_Tax_Core_Web_App.Pages.SalaryPayments
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
        ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public SalaryPayment SalaryPayment { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var employee =( from emp in _context.Employee
                           where emp.Id == SalaryPayment.EmployeeId select emp).FirstOrDefault();

            //Load the tax table tax record for this employee

            var taxRecord = (from tax in _context.TaxTable
                             where tax.TaxCode.Equals(employee.TaxCode)
                             select tax).FirstOrDefault();

            SalaryPayment.CalculatedTax = employee.SalaryPerAnnum * (taxRecord.TaxPercentage / 100);





            _context.SalaryPayment.Add(SalaryPayment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
