using AutoMapper;
using BusinessObjects;
using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIServices.CustomerServices
{
    public class RegisterService
    {
        private readonly PaymateDB _paymateDB;

        public RegisterService()
        {
            _paymateDB = new PaymateDB();
        }



        public void RegisterCustomer(CustomerBO customerBO)
        {
            Mapper.Initialize(c => c.CreateMap<CustomerBO, Customer>());
            var customer = Mapper.Map<Customer>(customerBO);
            _paymateDB.Customer.Add(customer);
            _paymateDB.SaveChanges();
        }
    }
}
