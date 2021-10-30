using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PETTWARE.Models
{
    class FornecedorValitador : AbstractValidator<Fornecedor>
    {
        public FornecedorValitador()
        {
            RuleFor(x => x.NomeForn).NotEmpty().WithMessage("O campo Nome é obrigatório.\n Por favor Preencha o Campo");
            RuleFor(x => x.NomeForn).NotEmpty().WithMessage("O campo Telefone é obrigatório.\n Por favor Preencha o Campo");
            RuleFor(x => x.NomeForn).NotEmpty().WithMessage("O campo E-mail é obrigatório.\n Por favor Preencha o Campo");
            RuleFor(x => x.NomeForn).NotEmpty().WithMessage("O campo Representante é obrigatório.\n Por favor Preencha o Campo");
            RuleFor(x => x.CNPJ).NotEqual("__.__.___/____-__").WithMessage("O campo CNPJ é obrigatório.\n Por favor Preencha o Campo");
            RuleFor(x => x.CNPJ).Must(CNPJValidator).WithMessage("CNPJ Inválido");
        }

        public bool CNPJValidator(string cnpj)
        {
            return true;
        }
    }

}       