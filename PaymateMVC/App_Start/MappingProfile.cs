using AutoMapper;
using BusinessObjects;
using PaymateMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymateMVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, UserBO>();
        }
    }
}