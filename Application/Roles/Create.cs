using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using DTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Roles
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Role Role { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Role).SetValidator(new RoleValidator());
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

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == _userAccessor.GetUsername());

                var roleObj = request.Role;
                if (user != null)
                {
                    roleObj.CreatedBy = user.Id;
                    roleObj.CreatedDate = DateTime.UtcNow;
                   
                }

                roleObj.CreatedDate = DateTime.UtcNow;

                _context.AppRoles.Add(roleObj);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create role");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}