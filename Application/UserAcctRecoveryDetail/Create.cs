using System;
using FluentValidation;
using MediatR;
using Domain;
using DTOs;
using Persistence;
using Application.Interfaces;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.UserAcctRecoveryDetail
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Domain.UserAcctRecoveryDetail UserAcctRecoveryDetail { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UserAcctRecoveryDetail).SetValidator(new AcctRecoveryValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

               // var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == _userAccessor.GetUsername());

               // var userAcctRecoveryObj = request.UserAcctRecoveryDetail;
               // if (user != null)
               // {
               //     userAcctRecoveryObj.UserId = user.Id;
               //     userAcctRecoveryObj.RequestCreateDate = DateTime.UtcNow;

               // }

               // roleObj.CreatedDate = DateTime.UtcNow;

                _context.UserAcctRecoveryDetails.Add(request.UserAcctRecoveryDetail);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create password recovery request");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
