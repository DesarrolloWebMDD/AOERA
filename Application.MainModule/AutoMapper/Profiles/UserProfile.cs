using Application.Dto;
using AutoMapper;
using Domain.MainModule.Entity;

namespace Application.MainModule.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Usuario, UserDto>()
                .ForMember(p => p.Name, q => q.MapFrom(r => r.Nombre))
                .ForMember(p => p.LastName, q => q.MapFrom(r => r.Apellidos))
                .ForMember(p => p.DocumentNumber, q => q.MapFrom(r => r.DNI))
                .ForMember(p => p.Phone, q => q.MapFrom(r => r.Telefono))
                .ForMember(p => p.Mail, q => q.MapFrom(r => r.Email))
                .ForMember(p => p.ImgName, q => q.MapFrom(r => r.ImagenOriginal))
                .ForMember(p => p.KeyName, q => q.MapFrom(r => r.KeyImagen))
                .ForMember(p => p.ReferenceCode, q => q.MapFrom(r => r.CodigoReferencia))
                .ForMember(p => p.InvitedCode, q => q.MapFrom(r => r.CodigoInvitacion))
                .ForMember(p => p.State, q => q.MapFrom(r => r.Estado))
                .ForMember(p => p.BirthdayDate, q => q.MapFrom(r => r.FechaNacimiento))
                //.ForMember(p => p.UserPoint, q => q.MapFrom(r => r.UsuarioPunto))
                .ReverseMap();
        }
    }
}