using AutoMapper;
using BusinessObjects;
using Common;
using Common.Enumarations;
using DataAccess;
using DataAccess.Models;
using Message;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UIServices.CustomerServices
{
    public class RegisterService
    {
        private readonly PaymateDB _paymateDB;

        public RegisterService(PaymateDB paymateDB)
        {
            _paymateDB = paymateDB;
        }

        public async Task RegisterCustomerAsync(UserBO userBO)
        {
            var customer = Mapper.Map<Customer>(userBO);
            _paymateDB.Customer.Add(customer);
            await _paymateDB.SaveChangesAsync();
        }

        public async Task ConfirmEmailAsync(string id)
        {
            try
            {
                var DecryptedEmail = MessageBuilder.Decrypt(id);
                var EmailConfirmed = _paymateDB.Customer.Single(w => w.CustomerEmailAddress == DecryptedEmail && w.Status == (int)CustomerStatusEnum.Active && w.EmailConfirmed == false);
                EmailConfirmed.EmailConfirmed = true;
                await _paymateDB.SaveChangesAsync();
            }
            catch
            {

            }
        }

        public async Task<bool> GetUserEmailAsync(string NewUserEmailAddress)
        {
            var userEamailExist = await _paymateDB.Customer.AsNoTracking().AnyAsync(w => w.CustomerEmailAddress == NewUserEmailAddress);
            return userEamailExist;
        }
    }
}
