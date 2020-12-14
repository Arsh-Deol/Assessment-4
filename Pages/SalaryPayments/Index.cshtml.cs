using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Employee_Payee_Tax_Core_Web_App.BusinessLayer;
using Employee_Payee_Tax_Core_Web_App.Models;

namespace Employee_Payee_Tax_Core_Web_App.Pages.SalaryPayments
{
    public class IndexModel : PageModel
    {
        private readonly Employee_Payee_Tax_Core_Web_App.Models.Employee_Payee_Tax_DataContext _context;

        public IndexModel(Employee_Payee_Tax_Core_Web_App.Models.Employee_Payee_Tax_DataContext context)
        {
            _context = context;
        }

        public IList<SalaryPayment> SalaryPayment { get;set; }

        public async Task OnGetAsync()
        {
            SalaryPayment = await _context.SalaryPayment
                .Include(s => s.Employee).ToListAsync();
        }
    }
}
