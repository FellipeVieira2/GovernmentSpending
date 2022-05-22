using GovernmentSpending.Application.PresidentSpending.Queries.GetAllSpendingsQuery;
using Microsoft.AspNetCore.Mvc;

namespace GovernmentSpending.Api.Controllers
{
    public class PresidentSpending : ApiControllerBase
    {

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPresidentSpending([FromRoute] int id)
        {
           
            var command = new GetAllSpendingsQuery();
            command.Id = id;
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
