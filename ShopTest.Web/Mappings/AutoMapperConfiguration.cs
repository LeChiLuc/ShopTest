using AutoMapper;
using ShopTest.Model.Models;
using ShopTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTest.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<ContactDetail, ContactDetailViewModel>();
        }
    }
}