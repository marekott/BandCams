using System.Threading.Tasks;
using DatabaseAccess.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoredProceduresController : ControllerBase
    {
        private readonly IStoredProceduresData _storedProceduresData;

        public StoredProceduresController(IStoredProceduresData storedProceduresData)
        {
            _storedProceduresData = storedProceduresData;
        }

        [HttpPost]
        [Route("CloseOldStreams")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CloseOldStreams(CloseOldStream closeOldStream)
        {
            await _storedProceduresData.CloseOldStreams(closeOldStream.DateTimeNowUtc, closeOldStream.OlderThanInMinutes);

            return Ok();
        }
    }
}