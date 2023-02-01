using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using FluentValidation;

namespace Domain.MainModule.Validations
{
    public class DeporteValidator : AbstractValidator<Deportes>
    {
        private readonly IDeportesRepository _deportesRepository;
        public DeporteValidator(IDeportesRepository deportesRepository)
        {
            _deportesRepository = deportesRepository;
        }
    }
}
