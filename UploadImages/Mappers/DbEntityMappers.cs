using AutoMapper;
using UploadImages.ApplicationModels;
using UploadImages.Models;

namespace UploadImages.Mappers
{
    public class DbEntityMappers : Profile
    {
        public DbEntityMappers()
        {
            CreateMap<ApplicationAccount,Account>().ReverseMap();

            CreateMap<ApplicationPost, Post>().ReverseMap();

            CreateMap<ApplicationComment, Comment>().ReverseMap();
        }
    }
}
