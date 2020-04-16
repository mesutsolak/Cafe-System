using AutoMapper;
using CP.Mobile.ValidatorEntities;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CP.Mobile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();
        }
    }
}
