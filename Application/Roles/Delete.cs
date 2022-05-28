using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using DTOs;
using MediatR;
using Persistence;

namespace Application.Roles
{
    public class Delete
    {
        public class Command: IRequest<Result<Unit>>
        {
            public Guid Id{get;set;}
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                 var role = await _context.AppRoles.FindAsync(request.Id);
                if(role==null){
                    return null;
                }
               
                _context.Remove(role);
                var result = await _context.SaveChangesAsync()>0;
                if(!result) return Result<Unit>.Failure("Failed to delete the role");
                return Result<Unit>.Success(Unit.Value);
            }

           
        }
    }
}