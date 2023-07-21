using AutoMapper;
using MTFTest.UsersModule.Models;
using MTFTest.UsersModule.Views;

namespace MTFTest.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<CredentialsView, Credentials>();
        }
    }
}
