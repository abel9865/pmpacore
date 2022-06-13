using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DTOs;
using MediatR;
using Persistence;

namespace Application.UserAcctRecoveryDetail
{
    
        public class Details
        {
            public class Query : IRequest<Result<Domain.UserAcctRecoveryDetail>>
            {
                public string Token { get; set; }

               
            }

            public class Handler : IRequestHandler<Query, Result<Domain.UserAcctRecoveryDetail>>
            {
                private readonly DataContext _context;
                private readonly IMapper _mapper;
                public Handler(DataContext context, IMapper mapper)
                {

                    _context = context;
                    _mapper = mapper;

                }

                public   async Task<Result<Domain.UserAcctRecoveryDetail>> Handle(Query request, CancellationToken cancellationToken)
                {
                  
                      var  userAcctRecoveryDetail =  _context.UserAcctRecoveryDetails.Where(x => x.RecoveryToken == request.Token).FirstOrDefault();
                    
                    return Result<Domain.UserAcctRecoveryDetail>.Success(userAcctRecoveryDetail);
                }

               
            }
        }
    
}
