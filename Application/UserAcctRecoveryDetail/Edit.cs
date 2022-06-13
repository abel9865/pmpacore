using System;
using FluentValidation;
using Domain;
using MediatR;
using DTOs;
using Persistence;
using AutoMapper;
using Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.UserAcctRecoveryDetail
{
    public class Edit
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
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var userAcctRecoveryDetail = await _context.AppRoles.FindAsync(request.UserAcctRecoveryDetail.Id);

                if (userAcctRecoveryDetail == null) return null;

               
                _mapper.Map(request.UserAcctRecoveryDetail, userAcctRecoveryDetail);
                
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update password recovery request");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
