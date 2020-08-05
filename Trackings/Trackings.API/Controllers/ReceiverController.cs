using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Trackings.Application.Queries;

namespace Trackings.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiverController : ControllerBase
    {
        private readonly IReceiverQuery _receiverQuery;

        public ReceiverController(IReceiverQuery receiverQuery)
        {
            _receiverQuery = receiverQuery;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ReceiverViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> findAll()
        {
            var result = await _receiverQuery.findAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("{receiverId}")]
        [ProducesResponseType(typeof(ReceiverViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> findById(int receiverId)
        {
            var result = await _receiverQuery.findById(receiverId);

            return Ok(result);
        }
    }
}