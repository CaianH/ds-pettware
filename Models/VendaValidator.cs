using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PETTWARE.Models
{
    class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            RuleFor(X => X.Funcionario).NotEmpty().WithMessage("Selecione um Funcionário Por Favor.");
            RuleFor(X => X.Cliente).NotEmpty().WithMessage("Selecione um Cliente Por Favor.");
            RuleFor(X => X.Data).NotEmpty().WithMessage("Selecione a Data da Venda Por Favor.");
            RuleFor(X => X.FormaPagamento).NotEmpty().WithMessage("Selecione uma Forma de Pagamento Por Favor.");
            RuleFor(X => X.Itens).NotEmpty().WithMessage("Selecione ao menos 1 Item Para Realizar a Venda.");
        }
    }
}
