using AutoMapper;
using Core.Common.Exceptions;
using Core.Data;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Core.Dreams.Commands
{
    public class UpdateDream 
    {
        public class Command : IRequest<Dream>
        {
            public Dream Dream { get; set; }
        }

        public class Handler : IRequestHandler<Command, Dream>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Dream> Handle(Command request, CancellationToken cancellationToken)
            {
                var dream = await _context.Dreams.FirstOrDefaultAsync(x => x.Id == request.Dream.Id, cancellationToken);

                if (dream == null)
                {
                    throw new NotFoundException(nameof(Dream), request.Dream.Id);
                }

                _mapper.Map(request.Dream, dream);

                await _context.SaveChangesAsync(cancellationToken);

                return dream;
            }
        }
    }
    
}