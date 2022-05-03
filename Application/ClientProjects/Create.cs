using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.ClientProjects
{
    public class Create
    {
        public class Command: IRequest<Result<Unit>>
        {
            public ClientProject ClientProject{get;set;}
        }

        public class CommandValidator:AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x=>x.ClientProject).SetValidator(new ClientProjectValidator());
            }
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
                _context.ClientProjects.Add(request.ClientProject);
                var result = await _context.SaveChangesAsync()>0;
                if (!result) return Result<Unit>.Failure("Failed to create clientproject");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}