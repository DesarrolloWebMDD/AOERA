using Application.Dto.Security;
using Application.Security.Entity;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, AppUser>()
                .ForMember(p => p.UserName, q => q.MapFrom(r => r.UserName))
                .ForMember(p => p.Email, q => q.MapFrom(r => r.Email));
            //.ForMember(p => p.CurrentRolId, q => q.MapFrom(r => r.RolList.OrderBy(p => p.RolId).First().RolId));

            CreateMap<AppUserToken, LoginResponseDto>()
                .ForMember(x => x.Token, m => m.MapFrom(d => d.Token))
                .ForMember(x => x.ConfirmedEmail, m => m.MapFrom(d => true));
        }
    }
}