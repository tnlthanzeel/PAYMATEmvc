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
        private readonly PaymateDB _paymateDB;

        public LoginService(PaymateDB paymateDB)
        {
            _paymateDB = paymateDB;
        }

        public async Task<UserBO> GetUserAsync(string CustomerEmail, string Password)
        {
            var UserBO =await _paymateDB.Customer.AsNoTracking().Where(w => w.CustomerEmailAddress == CustomerEmail && w.CustomerPassword == Password && w.Status == (int)CustomerStatusEnum.Active && w.EmailConfirmed == true)
                .Select(s => new UserBO()
                {
                    CustomerEmailAddress = s.CustomerEmailAddress,
                }).FirstOrDefaultAsync();
            return UserBO;
        }
    }
}
