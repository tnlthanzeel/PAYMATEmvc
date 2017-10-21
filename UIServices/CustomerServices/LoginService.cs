using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Common;

namespace UIServices.CustomerServices
{

    public class LoginService
    {

        private readonly PaymateDB _customer;

        public LoginService()
        {
            _customer = new PaymateDB();
        }

        public Customer Login(string CustomerEmail, string Password)
        {
            
            var customerlogin = _customer.Customer.FirstOrDefault(w => w.CustomerEmailAddress == CustomerEmail && w.CustomerPassword == Password && w.Status==(int)CustomerStatusEnum.Active);

            return customerlogin;


        }


    }
}
