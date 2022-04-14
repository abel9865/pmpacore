using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.ClientProjects
{
    public class Edit
    {
        public class Command:IRequest
        {
          public ClientProject ClientProject{get; set;}
        }


        public class Handler : IRequestHandler<Command>
        {
        private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
             _context = context;
             _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var clientProject = await _context.ClientProjects.FindAsync(request.ClientProject.ProjectId);
                _mapper.Map(request.ClientProject, clientProject);
                // clientProject.ProjectTitle = request.ClientProject.ProjectTitle?? clientProject.ProjectTitle;
                // clientProject.ProjectStatus = request.ClientProject.ProjectStatus;
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}