using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Employee_Payee_Tax_Core_Web_App.BusinessLayer;

namespace Employee_Payee_Tax_Core_Web_App.Models
{
    public class Employee_Payee_Tax_DataContext : DbContext
    {
        public Employee_Payee_Tax_DataContext (DbContextOptions<Employee_Payee_Tax_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Employee_Payee_Tax_Core_Web_App.BusinessLayer.Company> Company { get; set; }

        public DbSet<Employee_Payee_Tax_Core_Web_App.BusinessLayer.Employee> Employee { get; set; }

        public DbSet<Employee_Payee_Tax_Core_Web_App.BusinessLayer.SalaryPayment> SalaryPayment { get; set; }

        public DbSet<Employee_Payee_Tax_Core_Web_App.BusinessLayer.TaxTable> TaxTable { get; set; }
    }
}
