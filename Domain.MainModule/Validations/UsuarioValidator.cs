using System.Threading.Tasks;
using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using FluentValidation;
using Infrastructure.CrossCutting.Enum;
using Microsoft.EntityFrameworkCore;

namespace Domain.MainModule.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioValidator(IUsuarioRepository usuarioRepository, int type)
        {
            _usuarioRepository = usuarioRepository;
            RuleFor(x => x).MustAsync((persona, cancel) => DuplicateCorreo(persona, type))
                .WithMessage("El correo  ya existe registrado");
        }

        public async Task<bool> DuplicateCorreo(Usuario usuario, int type)
        {
            bool count = true;
            if (type == (int) CrudOptionEnum.CreateValidation)
                count = await _usuarioRepository.Find(x => x.Email == usuario.Email).CountAsync() == 0;
            return count;
        }
    }
}