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
using Persistence;

namespace Application.Roles
{
    public class Details
    {
        public class Query: IRequest<Result<List<RoleDto>>>
        {
            public Guid Id{get;set;}

            public SearchByEnums SearchBy{get;set;}
        }

        public class Handler : IRequestHandler<Query, Result<List<RoleDto>>>
        {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper )
            {
         
            _context = context;
            _mapper = mapper;

            }

            public async Task<Result<List<RoleDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
              var roles= new List<RoleDto>();
              if(request.SearchBy == SearchByEnums.ByKey){
                  roles =  await _context.AppRoles.ProjectTo<RoleDto>(_mapper.ConfigurationProvider).Where(x=>x.RoleId==request.Id).ToListAsync();
              }
              if(request.SearchBy == SearchByEnums.ByProjectId){
                  roles =  await _context.AppRoles.ProjectTo<RoleDto>(_mapper.ConfigurationProvider).Where(x=>x.ProjectId==request.Id).ToListAsync();
              }
               if(request.SearchBy == SearchByEnums.ByClientId){
                  roles =  await _context.AppRoles.ProjectTo<RoleDto>(_mapper.ConfigurationProvider).Where(x=>x.ClientId==request.Id).ToListAsync();
              }
              return Result<List<RoleDto>>.Success(roles);
            }

           
        }
    }
}