using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Application.Core;
using Domain;
using DTOs;
using Microsoft.AspNetCore.Http;
using System.Threading;
using Persistence;
using Application.Interfaces;
using AutoMapper;

namespace Application.Photos
{
    public class Add
    {
        public class Command: IRequest<Result<PhotoDto>>{
            public IFormFile File{get;set;}
        }

        public class Handler : IRequestHandler<Command, Result<PhotoDto>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;


            public Handler(DataContext context, IPhotoAccessor photoAccessor, IUserAccessor userAccessor, IMapper mapper)
            {
                _context = context;
                _photoAccessor = photoAccessor;
                _userAccessor = userAccessor;
                _mapper = mapper;
            }

            public async Task<Result<PhotoDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Include(p => p.UserPhoto).FirstOrDefaultAsync(x => x.Email == _userAccessor.GetUsername());
                if (user == null) return null;
                var photoUploadResult = await _photoAccessor.AddPhoto(request.File);
                var photo = new AppUserPhoto
                {
                    Id = photoUploadResult.PublicId,
                    Url = photoUploadResult.Url
                };

                user.UserPhoto = photo;

                var result = await _context.SaveChangesAsync() > 0;
                if (result) return Result<PhotoDto>.Success(_mapper.Map<PhotoDto>(photo));
                return Result<PhotoDto>.Failure("Problem adding ");
            }
        }
    }
}