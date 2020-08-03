using System;
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
    public class OnlineEventController : ControllerBase
    {
        private readonly IOnlineEventData _onlineEventData;

        public OnlineEventController(IOnlineEventData onlineEventData)
        {
            _onlineEventData = onlineEventData;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<OnlineEvent>), 200)]
        public async Task<IActionResult> Get(DateTime? fromDate, DateTime? toDate)
        {
            fromDate ??= new DateTime(1753, 1, 1); //min wartość DateTime2 na bazie
            toDate ??= DateTime.MaxValue;

            var output = await _onlineEventData.GetAll(fromDate, toDate);

            return Ok(output);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(OnlineEvent), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var output = await _onlineEventData.Get(id);

            return output.ToString() == "[]" ? (IActionResult) NotFound() : Ok(output);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CreatedRow), 201)]
        public async Task<IActionResult> Post(OnlineEvent onlineEvent)
        {
            var output = await _onlineEventData.Insert(onlineEvent);

            return Created("", output);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, OnlineEvent onlineEvent)
        {
            var row = await _onlineEventData.Get(id);

            if (row.ToString() == "[]")
            {
                return NotFound();
            }

            await _onlineEventData.Update(id, onlineEvent);

            return NoContent();
        }
    }
}