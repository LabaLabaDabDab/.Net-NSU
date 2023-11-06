using CardDeck;
using Microsoft.AspNetCore.Mvc;
using Common;

namespace ElonWeb
{
    [ApiController]
    public class ElonController : ControllerBase
    {
        [Route("game")]
        [HttpGet]
        public async Task<CardColor> GetColor()
        {
            await ResourceLockManager.WaitForResourceAsync();
            return await Task.FromResult(ElonDeck.Color);
        }
    }
}