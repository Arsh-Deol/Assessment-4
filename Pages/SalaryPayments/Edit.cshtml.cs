using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee_Payee_Tax_Core_Web_App.BusinessLayer;
using Employee_Payee_Tax_Core_Web_App.Models;

namespace Employee_Payee_Tax_Core_Web_App.Pages.SalaryPayments
{
    public class EditModel : PageModel
    {
        private readonly Employee_Payee_Tax_Core_Web_App.Models.Employee_Payee_Tax_DataContext _context;

        public EditModel(Employee_Payee_Tax_Core_Web_App.Models.Employee_Payee_Tax_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalaryPayment SalaryPayment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalaryPayment = await _context.SalaryPayment
                .Include(s => s.Employee).FirstOrDefaultAsync(m => m.Id == id);

            if (SalaryPayment == null)
            {
                return NotFound();
            }
           ViewData["EmployeeId"] = new SelectList(_context.Employee, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            var employee = (from emp in _context.Employee
                            where emp.Id == SalaryPayment.EmployeeId
                            select emp).FirstOrDefault();

            //Load the tax table tax record for this employee

            var taxRecord = (from tax in _context.TaxTable
                             where tax.TaxCode.Equals(employee.TaxCode)
                             select tax).FirstOrDefault();

            SalaryPayment.CalculatedTax = employee.SalaryPerAnnum * (taxRecord.TaxPercentage / 100);

            _context.Attach(SalaryPayment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryPaymentExists(SalaryPayment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SalaryPaymentExists(int id)
        {
            return _context.SalaryPayment.Any(e => e.Id == id);
        }
    }
}
