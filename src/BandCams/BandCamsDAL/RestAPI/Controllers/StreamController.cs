using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading.Tasks;
using DatabaseAccess.DataAccess.Interfaces;
using Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueueHelper.Interfaces;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        private readonly IStreamData _streamData;
        private readonly IEmailTemplatesData _emailTemplatesData;
        private readonly IQueueManager _queueManager;

        public StreamController(IStreamData streamData, IEmailTemplatesData emailTemplatesData, IQueueManager queueManager)
        {
            _streamData = streamData;
            _emailTemplatesData = emailTemplatesData;
            _queueManager = queueManager;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<Stream>), 200)]
        public async Task<IActionResult> Get([Required]bool isActive)
        {
            var output = await _streamData.GetAll(isActive);

            return Ok(output);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Stream), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var output = await _streamData.Get(id);

            return output.ToString() == "[]" ? (IActionResult)NotFound() : Ok(output);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CreatedRow), 201)]
        public async Task<IActionResult> Post(Stream stream)
        {
            var output = await _streamData.Insert(stream);

            var template = await _emailTemplatesData.Get<EmailQueueMessage>("NewStreamAdded");
            ReplaceTemplateVariables(stream.Link, template);

            //This part needs existing Azure Queue to work correctly.
            //await _queueManager.AddToQueueAsync(template);

            return Created("", output);
        }

        private static void ReplaceTemplateVariables(string link, EmailQueueMessage template)
        {
            template.Body = template.Body.Replace("#{CreateDate}#", DateTime.Now.ToString(CultureInfo.CurrentCulture));
            template.Body = template.Body.Replace("#{Link}#", link);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, Stream stream)
        {
            var row = await _streamData.Get(id);

            if (row.ToString() == "[]")
            {
                return NotFound();
            }

            await _streamData.Update(id, stream);

            return NoContent();
        }
    }
}