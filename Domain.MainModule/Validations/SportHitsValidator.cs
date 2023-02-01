using Domain.MainModule.Entity;
using Domain.MainModule.IRepository;
using FluentValidation;

namespace Domain.MainModule.Validations
{
    public class SportHitsValidator : AbstractValidator<Aciertos>
    {
        private readonly IAciertosRepository _aciertosRepository;

        public SportHitsValidator(IAciertosRepository aciertosRepository)
        {
            _aciertosRepository = aciertosRepository;
        }

    }
}
