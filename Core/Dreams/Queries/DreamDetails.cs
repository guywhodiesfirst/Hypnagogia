using Core.Common.Exceptions;
using Core.Data;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Dreams.Queries
{
    public class DreamDetails
    {
        public class Query: IRequest<Dream>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Dream>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Dream> Handle(Query request, CancellationToken cancellationToken)
            {
                var dream = await _context.Dreams.FirstOrDefaultAsync(x => x.Id == request.Id);
                if(dream == null)
                {
                    throw new NotFoundException(nameof(Dream), request.Id);
                }
                return dream;
            }

        }
    }
}