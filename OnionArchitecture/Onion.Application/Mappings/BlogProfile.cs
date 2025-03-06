using AutoMapper;
using MongoDB.Bson;
using OnionArchitecture.Core.Models;
using OnionArchitecture.Application.DTOs;

namespace OnionArchitecture.Application.Mappings
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog, BlogDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString())) // ✅ Convert ObjectId to string
                .ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.Id) ? ObjectId.GenerateNewId().ToString() : src.Id)); // ✅ Ensure correct mapping
        }
    }
}
