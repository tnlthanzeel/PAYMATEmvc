using Common.Enumarations;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace UIServices.CustomerServices
{
    public class ResetPasswordService
    {
        private readonly PaymateDB _paymateDB;

        public ResetPasswordService(PaymateDB paymateDB)
        {
            _paymateDB = paymateDB;
        }

        public async Task UpdatedResetedPasswordAsync(string emailToResetPassword, string newPassword)
        {
            var EmailToUpdatePassword = await _paymateDB.Customer.FirstOrDefaultAsync(x => x.CustomerEmailAddress == emailToResetPassword && x.Status == (int)CustomerStatusEnum.Active);
            EmailToUpdatePassword.CustomerPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword, "SHA1");
            await _paymateDB.SaveChangesAsync();
        }
    }
}
