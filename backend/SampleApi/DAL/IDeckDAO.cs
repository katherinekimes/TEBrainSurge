using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEFlashCards.Models;

namespace TEFlashCards.DAL
{
    public interface IDeckDAO
    {
        /// <summary>
        /// Creates a new deck.
        /// </summary>
        /// <param name="deck"></param>
        void CreateDeck(Deck deck, int userId);

        /// <summary>
        /// Retrieves a user from the system by username.
        /// </summary>
        /// <param name="deckname"></param>
        /// <returns></returns>
        Deck GetDeck(int deckId);

        IList<Deck> GetAllDecks();

        bool DeleteDeck(int deckId);

        bool ModifyDeck(Deck deck);

    }
}
