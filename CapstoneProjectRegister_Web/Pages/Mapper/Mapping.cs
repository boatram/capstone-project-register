using AutoMapper;
using CapstoneProject.Repository.DTO;
using CapstoneProject.Repository.Model;

namespace CapstoneProjectRegister.Web.Pages.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<LoginLecturer, Lecturer>().ReverseMap();
        }

    }
}
