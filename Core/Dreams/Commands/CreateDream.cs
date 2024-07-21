using Core.Data;
using Core.Entities;
using MediatR;
namespace Core.Dreams.Commands
{
    public class CreateDream
    {
        public class Command: IRequest<Dream>
        {
            public Dream Dream { get; set; }
        }
        public class Handler : 
            IRequestHandler<Command, Dream>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Dream> Handle(Command request, 
                CancellationToken cancellationToken)
            {
                var dream = new Dream 
                {
                    Id = Guid.NewGuid(),
                    Title = request.Dream.Title,
                    Description = request.Dream.Description,
                    DreamMood = request.Dream.DreamMood,
                    CreatedAt = DateTime.Now
                };

                await _context.Dreams.AddAsync(dream, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return dream;
            }
        }
    }
}