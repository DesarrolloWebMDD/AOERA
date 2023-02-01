using System.Threading.Tasks;
using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using FluentValidation;
using Infrastructure.CrossCutting.Enum;
using Microsoft.EntityFrameworkCore;

namespace Domain.MainModule.Validations
{
    public class UserValidator : AbstractValidator<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UserValidator(IUsuarioRepository usuarioRepository, int type)
        {
            _usuarioRepository = usuarioRepository;
            RuleFor(x => x).MustAsync((usuario, cancel) => Duplicate(usuario, type))
                .WithMessage("Ya hay un usuario con este dni ...!");
        }

        public async Task<bool> Duplicate(Usuario usuario, int type)
        {
            bool count = true;
            if (type == (int) CrudOptionEnum.CreateValidation)
                count = await _usuarioRepository.Find(x => x.DNI == usuario.DNI || x.UserName == usuario.UserName || x.Email == usuario.Email).CountAsync() == 0;
            return count;
        }
    }
}