using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TEFlashCards.Models;

namespace TEFlashCards.DAL
{
    public class Card_DeckSqlDAO : ICard_DeckDAO
    {

        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for user objects.
        /// </summary>
        /// <param name="connectionString"></param>
        
        public Card_DeckSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public void AddCard(int cardId, int deckId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO card_deck(CardId, DeckId) VALUES (@cardId, @deckId)", conn);
                    cmd.Parameters.AddWithValue("@cardId", cardId);
                    cmd.Parameters.AddWithValue("@deckId", deckId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteCard(int cardId, int deckId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM card_deck WHERE cardId = @cardId AND deckId = @deckId", conn);
                    cmd.Parameters.AddWithValue("@cardId", cardId);
                    cmd.Parameters.AddWithValue("@deckId", deckId);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
