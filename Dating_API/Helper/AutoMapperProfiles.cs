using AutoMapper;
using Dating_API.DTO;
using Dating_API.Entity;

namespace Dating_API.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser,MemberDto>()
            .ForMember(dest=>dest.PhotoUrl,opt=>
            opt.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url));
            
            CreateMap<Photos,PhotoDto>();
        }
    }
}