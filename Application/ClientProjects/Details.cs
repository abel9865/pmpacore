using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ClientProjects
{
    public class Details
    {
        public class Query: IRequest<List<ClientProject>>
        {
            public Guid Id{get;set;}
        }

        public class Handler : IRequestHandler<Query, List<ClientProject>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;

            }

            public async Task<List<ClientProject>> Handle(Query request, CancellationToken cancellationToken)
            {
              return await _context.ClientProjects.Where(x=>x.ClientId==request.Id).ToListAsync();
            }
        }
    }
}