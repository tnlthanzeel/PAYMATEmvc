using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class PaymateDB : DbContext

    {
        public PaymateDB() : base("paymatecontext") { }
       
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Gender> Gender { get; set; }
    }
}
