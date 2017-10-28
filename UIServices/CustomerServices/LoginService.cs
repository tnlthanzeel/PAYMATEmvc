using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Common.Enumarations;
using BusinessObjects;

namespace UIServices.CustomerServices
{

    public class LoginService
    {

        private readonly PaymateDB _customer;

        public LoginService()
        {
            _customer = new PaymateDB();
        }

        public UserBO Login(string CustomerEmail, string Password)
        {

            var UserBO = _customer.Customer.AsNoTracking().Where(w => w.CustomerEmailAddress == CustomerEmail && w.CustomerPassword == Password && w.Status == (int)CustomerStatusEnum.Active && w.EmailConfirmed == true)
                .Select(s => new UserBO()
                {
                    CustomerEmailAddress = s.CustomerEmailAddress,
                    EmailConfirmed = s.EmailConfirmed
                }).FirstOrDefault();

            return UserBO;


        }


    }
}
