using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Trackings.Application.Queries;

namespace Trackings.API.Controllers
{
    [Authorize]
    [Route("states")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateQuery _stateQuery;
        public StateController(
            IStateQuery stateQuery
            )
        {
            _stateQuery = stateQuery;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StateViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> findAll()
        {
            var result = await _stateQuery.findAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("find-by-id")]
        [ProducesResponseType(typeof(StateViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> findById(int parent_id, int user_type_id)
        {
            var result = await _stateQuery.findById(parent_id, user_type_id);

            return Ok(result);
        }
    }
}