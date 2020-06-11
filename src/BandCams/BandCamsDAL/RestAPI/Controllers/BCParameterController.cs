using System.Collections.Generic;
using System.Threading.Tasks;
using DatabaseAccess.DataAccess.Interfaces;
using Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // ReSharper disable once InconsistentNaming
    public class BCParameterController : ControllerBase
    {
        private readonly IBCParametersData _bcParametersData;

        public BCParameterController(IBCParametersData bcParametersData)
        {
            _bcParametersData = bcParametersData;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<BCParameter>), 200)]
        public async Task<IActionResult> Get()
        {
            var output = await _bcParametersData.GetAll();

            return Ok(output);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(BCParameter), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var output = await _bcParametersData.Get(id);

            return output.ToString() == "[]" ? (IActionResult)NotFound() : Ok(output);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CreatedRow), 201)]
        public async Task<IActionResult> Post(BCParameter bcParameter)
        {
            var output = await _bcParametersData.Insert(bcParameter);

            return Created("", output);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, BCParameter bcParameter)
        {
            var row = await _bcParametersData.Get(id);

            if (row.ToString() == "[]")
            {
                return NotFound();
            }

            await _bcParametersData.Update(id, bcParameter);

            return NoContent();
        }
    }
}