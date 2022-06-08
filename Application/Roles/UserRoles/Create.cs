using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Roles.UserRoles
{
   public class Create
    {
        public class Command: IRequest<Result<Unit>>
        {
            public string UserId {get;set;}
            public List<Role> Roles{get;set;}
        }

        // public class CommandValidator:AbstractValidator<Command>
        // {
        //     public CommandValidator()
        //     {
        //         RuleFor(x=>x.Role).SetValidator(new RoleValidator());
        //     }
        // }

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

var userInContext = await _context.Users.FirstOrDefaultAsync(x => x.Email == _userAccessor.GetUsername());

 var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);

var userRoles = new List<UserRole>();

foreach (var role in request.Roles){

   userRoles.Add(new UserRole{

       // User = user,
       //Role = role,
            RoleId = role.RoleId,
             UserId = user.Id,
            Status=true,

             LastUpdatedBy = userInContext.Id,
           LastUpdatedDate = DateTime.UtcNow,
           
            CreatedBy = userInContext.Id,
        CreatedDate = DateTime.UtcNow
    });
}

               

                _context.AppUserRoles.AddRange(userRoles);
                var result = await _context.SaveChangesAsync()>0;
                if (!result) return Result<Unit>.Failure("Failed to create user roles");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}