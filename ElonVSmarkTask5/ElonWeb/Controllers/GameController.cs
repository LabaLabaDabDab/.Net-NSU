using Microsoft.AspNetCore.Mvc;
using CardDeck;
using Strategy;

namespace ElonWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ICardStrategy _elonCardStrategy;

        public GameController(ICardStrategy elonCardStrategy)
        {
            _elonCardStrategy = elonCardStrategy;
        }

        [HttpPost("getchoice")]
        public IActionResult GetChoice([FromBody] List<Card> cards)
        {
            int elonChoice = _elonCardStrategy.SelectCard(cards.ToArray());

            return Ok(elonChoice);
        }
    }
}
