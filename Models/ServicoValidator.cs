using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PETTWARE.Models
{
    class ServicoValidator : AbstractValidator<Servico>
    {
        public ServicoValidator()
        {
            RuleFor(X => X.Nome).NotEmpty().WithMessage("O Campo Nome é Obrigatório.\n Por favor Preencha o Campo");
            RuleFor(X => X.PrecoNormal).NotEmpty().WithMessage("O Campo Preço Normal é Obrigatório.\n Por favor Preencha o Campo");
            RuleFor(X => X.PrecoComDesconto).NotEmpty().WithMessage("O Campo Preço Com Desconto é Obrigatório.\n Por favor Preencha o Campo");
            RuleFor(x => x.PrecoNormal).ExclusiveBetween(0, 100000).WithMessage(" Preço precisa ser maior que 0.\n Por favor Digite um preço válido");
            RuleFor(customer => customer.PrecoComDesconto).LessThanOrEqualTo(X => X.PrecoNormal);
        }
    }
}
