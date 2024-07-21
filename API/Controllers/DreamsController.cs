using Core.Entities;
using Core.Dreams.Queries;
using Core.Dreams.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Dream>>> GetDreams()
        {
            return await Mediator.Send(new DreamList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dream>> GetDream(Guid id)
        {
            return await Mediator.Send(new DreamDetails.Query{Id = id});
        }
        [HttpPost]
        public async Task<ActionResult<Dream>> Create(Dream dream)
        {
            return await Mediator.Send(new CreateDream.Command{Dream = dream});
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Dream>> Update(Dream dream, Guid id)
        {
            dream.Id = id;
            return await Mediator.Send(new UpdateDream.Command{Dream = dream});
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await Mediator.Send(new DeleteDream.Command{Id = id});
        }
        
    }
}