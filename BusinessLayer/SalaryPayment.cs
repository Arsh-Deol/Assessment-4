using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Payee_Tax_Core_Web_App.BusinessLayer
{
    public class SalaryPayment
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public decimal CalculatedTax { get; set; }
            
            

    }
}
