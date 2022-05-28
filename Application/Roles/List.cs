using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.Roles
{
    public class List
    {
        public class Query : IRequest<Result<List<RoleDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<RoleDto>>>
        {
            private readonly DataContext _context;
            private readonly ILogger<List> _logger;
            private readonly IMapper _mapper;

            public Handler(DataContext context, ILogger<List> logger, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
              
                _logger = logger;
            }

            public async Task<Result<List<RoleDto>>> Handle(Query request, CancellationToken cancellationToken)
            {

                var roles = await _context.AppRoles
                .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                // .Include(x => x.UserRoles)
                // .ThenInclude(x => x.User)
                .ToListAsync(cancellationToken);

                // var rolesToReturn = _mapper.Map<List<RoleDto>>(roles);

                return Result<List<RoleDto>>.Success(roles);
            }
        }
    }
}