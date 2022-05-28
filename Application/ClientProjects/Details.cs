using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ClientProjects
{
    public class Details
    {
        public class Query : IRequest<Result<List<ClientProject>>>
        {
            public Guid Id { get; set; }
            public SearchByEnums SearchBy { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<ClientProject>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }

            public async Task<Result<List<ClientProject>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var clientProjects = new List<ClientProject>();

                if (request.SearchBy == SearchByEnums.ByKey)
                {
                    clientProjects = await _context.ClientProjects.Where(x => x.ClientId == request.Id).ToListAsync();
                }


                if (request.SearchBy == SearchByEnums.ByProjectId)
                {
                    clientProjects = await _context.ClientProjects.Where(x => x.ProjectId == request.Id).ToListAsync();
                }


                return Result<List<ClientProject>>.Success(clientProjects);
            }
        }
    }
}