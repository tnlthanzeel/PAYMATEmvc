using BusinessObjects;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace UIServices.CustomerServices
{
    public class UserService
    {
        private readonly PaymateDB _paymateDB;

        public UserService(PaymateDB paymateDB)
        {
            _paymateDB = paymateDB;
        }


        public async Task<UserBO> GetUserInfoAsync(string userEmail)
        {
            var userDetail = await _paymateDB.Customer.FirstOrDefaultAsync(x => x.CustomerEmailAddress == userEmail);
            return Mapper.Map<UserBO>(userDetail);
        }

        public async Task UpadateUserInfoAsync(UserBO userBO, string userEmail)
        {
            var userDetail = await _paymateDB.Customer.FirstOrDefaultAsync(x => x.CustomerEmailAddress == userEmail);
            userDetail.ProfilePicUrl = userBO.ProfilePicUrl;
            await _paymateDB.SaveChangesAsync();
        }
    }
}
