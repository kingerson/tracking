using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Trackings.Application.Queries;

namespace Trackings.API.Controllers
{
    [Authorize]
    [Route("real-estates")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandQuery _brandQuery;
        public BrandController(
            IBrandQuery brandQuery
            )
        {
            _brandQuery = brandQuery;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BrandViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> findAll()
        {
            var result = await _brandQuery.findAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("{brandId}")]
        [ProducesResponseType(typeof(BrandViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> findById(int brandId)
        {
            var result = await _brandQuery.findById(brandId);

            return Ok(result);
        }

        [HttpGet]
        [Route("{realEstateId}/brands")]
        [ProducesResponseType(typeof(IEnumerable<BrandViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> findByMall(int realEstateId)
        {
            var result = await _brandQuery.findByMall(realEstateId);

            return Ok(result);
        }
    }
}