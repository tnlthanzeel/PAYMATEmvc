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
using System.Web.Security;

namespace UIServices.CustomerServices
{

    public class LoginService : RepositoryBase
    {

        public LoginService(PaymateDB paymateDB) : base(paymateDB) { }

        public async Task<UserBO> GetUserAsync(string CustomerEmail, string Password)
        {
            using (var context = CreateContext())
            {
                var UserBO = await context.Customer.AsNoTracking().Where(w => w.CustomerEmailAddress == CustomerEmail && w.CustomerPassword == Password && w.Status == (int)CustomerStatusEnum.Active)
                    .Select(s => new UserBO()
                    {
                        CustomerEmailAddress = s.CustomerEmailAddress,
                        EmailConfirmed = s.EmailConfirmed,
                        ProfilePicUrl = s.ProfilePicUrl
                    }).FirstOrDefaultAsync();
                return UserBO;
            }

        }

        public async Task UpdatedResetedPasswordAsync(string emailToResetPassword, string newPassword)
        {
            using (var context = CreateContext())
            {
                var EmailToUpdatePassword = await context.Customer.FirstOrDefaultAsync(x => x.CustomerEmailAddress == emailToResetPassword && x.Status == (int)CustomerStatusEnum.Active);
                EmailToUpdatePassword.CustomerPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword, "SHA1");
                EmailToUpdatePassword.EditedOn = DateTime.Now.ToLocalTime();
                await context.SaveChangesAsync();
            }
        }
    }
}
