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
    public class Card_DeckController : ControllerBase
    {
        private ICardDAO cardDAO;
        private IUserDAO userDAO;
        private IDeckDAO deckDAO;
        private ICard_DeckDAO card_deckDAO;
       

        public Card_DeckController(ICardDAO cardDAO, IUserDAO userDAO, IDeckDAO deckDAO, ICard_DeckDAO card_deckDAO)
        {
            this.cardDAO = cardDAO;
            this.userDAO = userDAO;
            this.deckDAO = deckDAO;
            this.card_deckDAO = card_deckDAO;
        }


        [HttpPost("addcard/{deckId}/{cardId}")]
        public IActionResult AddCard([FromBody]int cardId, int deckId)
        {
            card_deckDAO.AddCard(cardId, deckId);

            return NoContent();
        }

        [HttpDelete("deletecard/{deckId}/{cardId}")]
        public IActionResult DeleteCard([FromBody]int cardId, int deckId)
        {
            bool isDeleted = card_deckDAO.DeleteCard(cardId, deckId);

            return NoContent();
        }
    }

}