using System;
using DTOs;
using MediatR;
using FluentValidation;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using AutoMapper;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Application.Comments
{
    public class Create
    {
       public class Command : IRequest<Result<CommentDto>>
        {
            public string Body { get; set; }
            public Guid ResourceId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Body).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, Result<CommentDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;

            }

            public async Task<Result<CommentDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var resource = await _context.Resources.FindAsync(request.ResourceId);

                if (resource == null) return null;

                var user = await _context.Users.Include(p=>p.UserPhoto).FirstOrDefaultAsync(x => x.Email == _userAccessor.GetUsername());

                var comment = new Comment
                {
                    author = user,
                    Resource = resource,
                    Body = request.Body

                };

                resource.Comments.Add(comment);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Result<CommentDto>.Success(_mapper.Map<CommentDto>(comment));

                return Result<CommentDto>.Failure("Failed to add comment");




            }
        }
    }
}
