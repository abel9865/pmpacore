using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using DTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ClientProjects
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ClientProject ClientProject { get; set; }
        }


        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ClientProject).SetValidator(new ClientProjectValidator());
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
                var clientProject = await _context.ClientProjects.FindAsync(request.ClientProject.ProjectId);

                if (clientProject == null) return null;

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == _userAccessor.GetUsername());

                clientProject.LastUpdatedBy = user.Id;
                clientProject.ClientId = user.ClientId.Value;
                clientProject.LastUpdatedDate = DateTime.UtcNow;

                _mapper.Map(request.ClientProject, clientProject);
                // clientProject.ProjectTitle = request.ClientProject.ProjectTitle?? clientProject.ProjectTitle;
                // clientProject.ProjectStatus = request.ClientProject.ProjectStatus;
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update client project");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}