using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TEFlashCards.DAL;
using TEFlashCards.Models;

namespace TEFlashCards.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DeckController : ControllerBase
    {
        private IDeckDAO deckDAO;
        private IUserDAO userDAO;
        private ICard_DeckDAO card_deckDAO;

        /// <summary>
        /// Constructor for deck
        /// </summary>
        /// <param name="deckDAO"></param>
        public DeckController(IDeckDAO deckDAO, IUserDAO userDAO, ICard_DeckDAO card_deckDAO)
        {
            this.deckDAO = deckDAO;
            this.userDAO = userDAO;
            this.card_deckDAO = card_deckDAO;
        }


        /// <summary>
        /// Creates a new deck object.
        /// </summary>
        /// <param name="deck"></param>
        /// <returns></returns>
        [HttpPost("createdeck")]
        public IActionResult CreateDeck(Deck deck)
        {
            User user = userDAO.GetUser(User.Identity.Name);

            deckDAO.CreateDeck(deck, user.Id);
            return NoContent();
        }

        [HttpGet("getdeck/{deckId}")]
        public IActionResult GetDeck(int deckId)
        {
            Deck deck = deckDAO.GetDeck(deckId);
            return Ok(deck);
        }

        [HttpGet("getalldecks")]
        public ActionResult<IList<Deck>> GetAllDecks()
        {
            IList<Deck> decks = deckDAO.GetAllDecks();
            return Ok(decks);
        }

        [HttpDelete("deletedeck")]
        public ActionResult DeleteDeck([FromBody]int deckId)
        {
            bool isDeleted = deckDAO.DeleteDeck(deckId);

            return NoContent();
        }

        [HttpPut("modifydeck")]
        public IActionResult ModifyDeck([FromBody]Deck updatedDeck)
        {
            bool isModified = deckDAO.ModifyDeck(updatedDeck);
            return NoContent();
        }

    }
}