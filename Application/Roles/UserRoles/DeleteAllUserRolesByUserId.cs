using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Roles.UserRoles
{
    public class DeleteAllUserRolesByUserId
    {
        public class Command : IRequest
        {
            
            public string UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
             

                var userRoles = await _context.AppUserRoles.Where(x => 
                        x.UserId == request.UserId).ToListAsync();

                if (!userRoles.Any())
                    return Unit.Value;

                _context.AppUserRoles.RemoveRange(userRoles);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
