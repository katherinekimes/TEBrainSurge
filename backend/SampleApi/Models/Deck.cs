using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEFlashCards.Models
{
    public class Deck
    {
        /// <summary>
        /// The id of the deck.
        /// </summary>
        public int DeckId { get; set; }

        /// <summary>
        /// The id of the user who created the deck.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The name of the deck.
        /// </summary>        
        public string DeckName { get; set; }

        /// <summary>
        /// The description of the deck
        /// </summary>
        public string DeckDescription { get; set; }
    }
}
