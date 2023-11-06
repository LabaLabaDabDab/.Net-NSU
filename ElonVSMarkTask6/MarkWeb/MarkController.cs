using CardDeck;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace MarkWeb
{
    [ApiController]
    public class MarkController : ControllerBase
    {
        [Route("game")]
        [HttpGet]
        public async Task<CardColor> GetColor()
        {
            await ResourceLockManager.WaitForResourceAsync();
            return await Task.FromResult(MarkDeck.Color);
        }
    }
}