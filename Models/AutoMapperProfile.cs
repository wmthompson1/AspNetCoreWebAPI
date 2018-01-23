using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
//using AspNetCoreWebAPI.Dtos;
using AspNetCoreWebAPI.Models;
using AspNetCoreWebAPI.Entities;

// https://github.com/wmthompson1/aspnet-core-angular2-registration-login-example/blob/master/server/Helpers/AutoMapperProfile.cs

namespace AspNetCoreWebAPI.Models
{
    
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //CreateMap<Entities.Book, Models.BookDTO>();
            //CreateMap<Models.BookDTO, Entities.Book>();
            //CreateMap<Entities.Publisher, Models.PublisherDTO>();
            //CreateMap<Models.PublisherDTO, Entities.Publisher>();
            //CreateMap<Models.PublisherUpdateDTO, Entities.Publisher>();
            //CreateMap<Entities.Publisher, Models.PublisherUpdateDTO>();
            //CreateMap<Models.BookUpdateDTO, Entities.Book>();
            //CreateMap<Entities.Book, Models.BookUpdateDTO>();

            //CreateMap<Entities.Survey, Models.SurveyDTO>();
            // CreateMap<Models.SurveyDTO, Entities.Survey>();

            // William Thompson
            //CreateMap<User, UserDTO>();
            //CreateMap<UserDTO, User>();
        }
    }
}
