using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEFlashCards.Models;

namespace TEFlashCards.DAL
{
    public interface ICardDAO
    {
        void CreateCard(Card card, int userId);

        Card GetCard(int cardId); 

        IList<Card> GetAllCards();

        IList<Card> GetCardsByUser(int userId);

        IList<Card> GetCardsByTag(string tag);

        bool DeleteCard(int cardId);

        bool ModifyCard(Card card);

        IList<Card> GetAvailableCards(int deckId);

        IList<Card> GetCardsByDeck(int deckId);
    }
}
