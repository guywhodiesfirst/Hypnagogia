using Core.Data;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Core.Dreams.Queries
{
    public class DreamList
    {
        public class Query : IRequest<List<Dream>>{}
        public class Handler : IRequestHandler<Query, List<Dream>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Dream>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dreams = await _context.Dreams.ToListAsync();
                return dreams;
            }
        }
    }
}