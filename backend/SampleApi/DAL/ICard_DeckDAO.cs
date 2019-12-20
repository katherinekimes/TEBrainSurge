using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEFlashCards.Models;

namespace TEFlashCards.DAL
{
    public interface ICard_DeckDAO
    {
        void AddCard(int cardId, int deckId);

        bool DeleteCard(int cardId, int deckId);
    }
}
