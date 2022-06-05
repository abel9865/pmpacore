using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Comments
{
    public class List
    {
       public class Query : IRequest<Result<List<CommentDto>>>
        {
            public Guid ResourceId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<CommentDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
           

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
               

            }
            public async Task<Result<List<CommentDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    // var comments = await _context.Comments.Where(x => x.Resource.ResourceId == request.ResourceId)
                    //                     .OrderBy(x => x.CreatedDate).ToListAsync();
                    //if (comments == null)
                    // {
                    //    return Result<List<CommentDto>>.Success(new List<CommentDto>());
                    //}
                    // var commentsObj = _mapper.Map<List<CommentDto>>(comments);

                    var commentsObj = await _context.Comments.Where(x => x.Resource.ResourceId == request.ResourceId)
                                          .OrderBy(x => x.CreatedDate).ProjectTo<CommentDto>(_mapper.ConfigurationProvider).ToListAsync();


                    return Result<List<CommentDto>>.Success(commentsObj);
                }
                catch (Exception ex)
                {
                    throw;
                }
               
            }
        }
    }
}
