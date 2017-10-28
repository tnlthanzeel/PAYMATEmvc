﻿using AutoMapper;
using BusinessObjects;
using Common;
using Common.Enumarations;
using DataAccess;
using DataAccess.Models;
using Message;
using System;
using System.Collections.Generic;
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

        public RegisterService()
        {
            _paymateDB = new PaymateDB();
        }


        public void RegisterCustomer(UserBO customerBO)
        {
            Mapper.Initialize(c => c.CreateMap<UserBO, Customer>());
            var customer = Mapper.Map<Customer>(customerBO);
            _paymateDB.Customer.Add(customer);
            _paymateDB.SaveChanges();
        }

        public void ConfirmEmail(string id)
        {
            var DecryptedEmail = MessageBuilder.Decrypt(id);
            var EmailConfirmed = _paymateDB.Customer.Single(w => w.CustomerEmailAddress == DecryptedEmail && w.Status == (int)CustomerStatusEnum.Active && w.EmailConfirmed == false);
            EmailConfirmed.EmailConfirmed = true;
            _paymateDB.SaveChanges();
        }
    }
}
