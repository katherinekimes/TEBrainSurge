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

    /// <summary>
    /// Card controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardDAO cardDAO;
        private IUserDAO userDAO;
        private IDeckDAO deckDAO;
        private ICard_DeckDAO card_deckDAO;

        public CardController(ICardDAO cardDAO, IUserDAO userDAO, IDeckDAO deckDAO, ICard_DeckDAO card_deckDAO)
        {
            this.cardDAO = cardDAO;
            this.userDAO = userDAO;
            this.deckDAO = deckDAO;
            this.card_deckDAO = card_deckDAO;
        }
        /// <summary>
        /// Retrieves all cards from the database.
        /// </summary>
        /// <returns>A list of the entire flashcard library</returns>
        [HttpGet("getallcards")]
        public ActionResult<IList<Card>> GetAllCards()
        {
            IList<Card> cards = cardDAO.GetAllCards();
            return Ok(cards);
        }

        [HttpGet("getcardbyid/{cardId}")]
        public ActionResult GetCard(int cardId)
        {
            Card card = cardDAO.GetCard(cardId);
            return Ok(card);
        }

        /// <summary>
        /// Given a tag returns a list of cards
        /// </summary>
        /// <param name="tag"></param>
        /// <returns>A list of cards by tag</returns>
        [HttpGet("getcardsbytag")]
        public ActionResult<IList<Card>> GetCardsByTag([FromBody]string tag)
        {
            IList<Card> cards = cardDAO.GetCardsByTag(tag);
            return Ok(cards); 
        }


        /// <summary>
        /// Given a UserId returns a list of cards
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>A List of cards by userId</returns>
        [HttpGet("getcardsbyuserid")]
        public ActionResult<IList<Card>> GetCardsByUserId()
        {
            User user = userDAO.GetUser(User.Identity.Name);
            IList<Card> cards = cardDAO.GetCardsByUser(user.Id);
            return Ok(cards);
        }

        /// <summary>
        /// Adds a new Flash Card to the Database
        /// </summary>
        /// <returns></returns>
        [HttpPost("createcard")]
        public IActionResult CreateCard(Card card)
        {
            User user = userDAO.GetUser(User.Identity.Name);
            
            cardDAO.CreateCard(card, user.Id);

            return NoContent();

        }

        /// <summary>
        /// Change the values of a single card matching the ID provided
        /// </summary>
        [HttpPut("modifycard")]
        public ActionResult ModifyCard([FromBody] Card updatedCard)
        {
            bool isModified = cardDAO.ModifyCard(updatedCard);
            return NoContent();
        }

        /// <summary>
        /// Removes a single card from the database matching the ID provided
        /// </summary>
        [HttpDelete("deletecard")]
        public ActionResult DeleteCard([FromBody]int cardId)
        {
            bool isDeleted = cardDAO.DeleteCard(cardId);

            return NoContent();
        }


        [HttpGet("getavailablecards/{deckId}")]
        public ActionResult<IList<Card>> GetAvailableCards(int deckId)
        {
            IList<Card> card = cardDAO.GetAvailableCards(deckId);
            return Ok(card);
        }

        [HttpGet("getcardsbydeck/{deckId}")]
        public ActionResult<IList<Card>> GetCardsByDeck(int deckId)
        {
            IList<Card> card = cardDAO.GetCardsByDeck(deckId);
            return Ok(card);
        }
    }
}