using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using MediatR;
using Persistence;

namespace Application.ClientProjects
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
                 var clientProject = await _context.ClientProjects.FindAsync(request.Id);
                if(clientProject==null){
                    return null;
                }
               
                _context.Remove(clientProject);
                var result = await _context.SaveChangesAsync()>0;
                if(!result) return Result<Unit>.Failure("Failed to delete the client project");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}