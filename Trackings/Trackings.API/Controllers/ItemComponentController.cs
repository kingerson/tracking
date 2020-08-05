using Trackings.Application.Commands;
using Trackings.Application.Queries.Interfaces;
using Trackings.Application.Queries.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealPlaza.Libs.Util;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Trackings.API.Controllers
{
    [Authorize]
    [Route("itemComponents")]
    [ApiController]
    public class ItemComponentController : ControllerBase
    {
        readonly IItemComponentQuery _iItemComponentQuery;
        readonly IMediator _mediator;

        public ItemComponentController(IItemComponentQuery iItemComponentQuery, IMediator mediator)
        {
            _iItemComponentQuery = iItemComponentQuery ?? throw new ArgumentNullException(nameof(iItemComponentQuery));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{itemComponentId}")]
        [ProducesResponseType(typeof(ItemComponentViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetById(int itemComponentId)
        {
            var result = await _iItemComponentQuery.GetById(itemComponentId);

            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(IEnumerable<ItemComponentViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBySearch([FromQuery] ItemComponentRequest request)
        {
            var result = await _iItemComponentQuery.GetBySearch(request);

            return Ok(result);
        }

        [HttpGet]
        [Route("find-all")]
        [ProducesResponseType(typeof(PaginationViewModel<ItemComponentViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByFindAll([FromQuery] ItemComponentRequest request)
        {
            var result = await _iItemComponentQuery.GetByFindAll(request);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateItemComponent(CreateItemComponentCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(CreateItemComponent), result);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateItemComponent(UpdateItemComponentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}