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
    public class RegisterService : RepositoryBase
    {
        public RegisterService(PaymateDB paymateDB) : base(paymateDB) { }
        public async Task RegisterCustomerAsync(UserBO userBO)
        {
            using (var context = CreateContext())
            {
                var customer = Mapper.Map<Customer>(userBO);
                context.Customer.Add(customer);
                await context.SaveChangesAsync();
            }
        }

        public async Task ConfirmEmailAsync(string id)
        {
            using (var context = CreateContext())
            {
                var DecryptedEmail = MessageBuilder.Decrypt(id);
                var EmailConfirmed = context.Customer.Single(w => w.CustomerEmailAddress == DecryptedEmail && w.Status == (int)CustomerStatusEnum.Active && w.EmailConfirmed == false);
                EmailConfirmed.EmailConfirmed = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> GetUserEmailAsync(string NewUserEmailAddress)
        {
            using (var context = CreateContext())
            {
                var userEamailExist = await context.Customer.AsNoTracking().AnyAsync(w => w.CustomerEmailAddress == NewUserEmailAddress);
                return userEamailExist;
            }
        }
    }
}
