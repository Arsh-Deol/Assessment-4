using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Payee_Tax_Core_Web_App.BusinessLayer
{
    public class TaxTable
    {
        public int Id { get; set; }
        public string TaxCode { get; set; }

        public decimal TaxPercentage { get; set; }

    }
}
