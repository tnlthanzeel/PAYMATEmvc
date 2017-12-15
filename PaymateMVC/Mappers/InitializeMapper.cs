using AutoMapper;
using BusinessObjects;
using DataAccess.Models;
using PaymateMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymateMVC.Mappers
{
    public class InitializeMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(m =>
            {
                m.CreateMap<LoginViewModel, UserBO>();
                m.CreateMap<RegisterViewModel, UserBO>();
                m.CreateMap<UserBO, Customer>();
                m.CreateMap<Customer, UserBO>();
            });
        }
    }
}