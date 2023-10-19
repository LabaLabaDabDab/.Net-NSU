using Microsoft.AspNetCore.Mvc;
using CardDeck;
using Strategy;

namespace MarkWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ICardStrategy _markCardStrategy;

        public GameController(ICardStrategy markCardStrategy)
        {
            _markCardStrategy = markCardStrategy;
        }

        [HttpPost("getchoice")]
        public IActionResult GetChoice([FromBody] List<Card> cards)
        {
            int markChoice = _markCardStrategy.SelectCard(cards.ToArray());

            return Ok(markChoice);
        }
    }
}

