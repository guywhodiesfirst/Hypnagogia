using Core.Common.Exceptions;
using Core.Data;
using Core.Entities;
using MediatR;

namespace Core.Dreams.Commands
{
    public class DeleteDream
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
        }
        public class Handler
        : IRequestHandler<Command, Unit>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var dream = await _context.Dreams.FindAsync(request.Id);
                if(dream == null)
                {
                    throw new NotFoundException(nameof(Dream), request.Id);
                }

                _context.Dreams.Remove(dream);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }

        }
    }
}