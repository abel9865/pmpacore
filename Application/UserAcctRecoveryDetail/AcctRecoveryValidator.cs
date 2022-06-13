using System;
using FluentValidation;
using Domain;

namespace Application.UserAcctRecoveryDetail
{
    public class AcctRecoveryValidator : AbstractValidator<Domain.UserAcctRecoveryDetail>
    {
        public AcctRecoveryValidator()
        {
            RuleFor(x => x.RecoveryToken).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.RequestCreateDate).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();



        }
    }
}
