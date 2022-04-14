using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.ClientProjects
{
    public class List
    {
        public class Query:IRequest<List<ClientProject>>{}

        public class Handler : IRequestHandler<Query, List<ClientProject>>
        {
        private readonly DataContext _context;
            private readonly ILogger<List> _logger;

            public Handler(DataContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<List<ClientProject>> Handle(Query request, CancellationToken cancellationToken)
            {

                try
                {
                    for(var i=0; i<10; i++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} has completed");

                    }
                }
                catch (Exception ex) when (ex is TaskCanceledException)
                {
                    
                   _logger.LogInformation("Task was cancelled");
                }
                return await _context.ClientProjects.ToListAsync(cancellationToken);
            }
        }
    }
}