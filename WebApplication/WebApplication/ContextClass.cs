using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication
{
    public class ContextClass: DbContext
    {
        public ContextClass() : base("DefaultConnection")
        {

        }
        public DbSet<EmployeeModel> employee { get; set; }
    }
}