namespace Lollipop.Application.MapperProfile
{
    using AutoMapper;
    using Lollipop.Application.DataTransferClasses;
    using Lollipop.Core.Models;

    public class UserProfile : Profile
    {
        public UserProfile(){
            CreateMap<AppUser, UserDto>()
                .ForMember(x => x.Username, y => y.MapFrom(z => z.UserName))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));
        }
    }
}
