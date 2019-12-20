using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TEFlashCards.Models;

namespace TEFlashCards.DAL
{
    public class CardSQLDAO : ICardDAO
    {
        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for user objects.
        /// </summary>
        /// <param name="connectionString"></param>
        public CardSQLDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateCard(Card card, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Card (UserId, FrontText, BackText, Tags) VALUES (@userId, @frontText, @backText, @tags)", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@frontText", card.FrontText);
                    cmd.Parameters.AddWithValue("@backText", card.BackText);
                    cmd.Parameters.AddWithValue("@tags", card.Tags);

                    cmd.ExecuteNonQuery();

                    return;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public Card GetCard(int cardId)
        {
            Card output = new Card();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CardId, UserId, FrontText, BackText, Tags, username From Card JOIN users ON card.UserId = users.id WHERE cardId = @cardId", conn);
                    cmd.Parameters.AddWithValue("@cardId", cardId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        output = RowToObject(reader);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return output;
        }

        /// <summary>
        /// Pulling all cards from the database
        /// </summary>
        /// <returns></returns>
        public IList<Card> GetAllCards()
        {
            List<Card> output = new List<Card>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT CardId, UserId, FrontText, BackText, Tags, username From Card JOIN users ON card.UserId = users.id";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Card card = RowToObject(reader);
                        output.Add(card);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return output;

        }

        public IList<Card> GetCardsByUser(int userId)
        {
            List<Card> output = new List<Card>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT CardId, UserId, FrontText, BackText, Tags, username From Card JOIN users ON card.UserId = users.id WHERE userId = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Card card = RowToObject(reader);
                        output.Add(card);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return output;
        }

        public IList<Card> GetCardsByTag(string tag)
        {
            List<Card> output = new List<Card>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from card WHERE Tags = @tag", conn);
                    cmd.Parameters.AddWithValue("@tag", tag);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Card card = RowToObject(reader);
                        output.Add(card);
                    }

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return output;
        }

        public IList<Card> GetCardsByDeck(int deckId)
        {
            List<Card> output = new List<Card>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM card_deck JOIN card on card.CardId = card_deck.CardId JOIN users ON card.UserId = users.id  WHERE DeckId = @deckId", conn);
                    cmd.Parameters.AddWithValue("@deckId", deckId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
          
                        Card card = RowToObject(reader);
                        output.Add(card);
                    }

                    

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return output;
        }

        private Card RowToObject(SqlDataReader reader)
        {
            Card card = new Card();
            card.CardId = Convert.ToInt32(reader["CardId"]);
            card.UserId = Convert.ToInt32(reader["UserId"]);
            card.FrontText = Convert.ToString(reader["FrontText"]);
            card.BackText = Convert.ToString(reader["BackText"]);
            card.Tags = Convert.ToString(reader["Tags"]);
            card.UserName = Convert.ToString(reader["Username"]);

            return card;
        }

        public bool DeleteCard(int cardId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Card WHERE cardId = @cardId", conn);
                    cmd.Parameters.AddWithValue("@cardId", cardId);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool ModifyCard(Card updatedCard)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Card SET FrontText = @updatedFrontText, BackText = @updatedBackText, Tags = @updatedTags WHERE CardId = @updatedCardId", conn);
                    cmd.Parameters.AddWithValue("@updatedCardId", updatedCard.CardId);
                    cmd.Parameters.AddWithValue("@updatedFrontText", updatedCard.FrontText);
                    cmd.Parameters.AddWithValue("@updatedBackText", updatedCard.BackText);
                    cmd.Parameters.AddWithValue("@updatedTags", updatedCard.Tags);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public IList<Card> GetAvailableCards(int deckId)
        {
            List<Card> output = new List<Card>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT card.CardId, card.UserId, card.FrontText, card.BackText, card.Tags, users.username FROM card JOIN card_deck on card.CardId = card_deck.CardId JOIN users ON card.UserId = users.id WHERE DeckId != @deckId AND card.cardId NOT IN(SELECT card_deck.CardId from card_deck WHERE deckID = @deckId)", conn))
                    {
                        // and also is not already in the current deck
                        cmd.Parameters.AddWithValue("@deckId", deckId);


                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Card card = RowToObject(reader);
                            output.Add(card);
                          
                        }
                        reader.Close();
                    }
               

                    using (SqlCommand cmd2 = new SqlCommand("SELECT * FROM card JOIN users ON card.UserId = users.id WHERE card.CardId NOT IN(SELECT card_deck.CardId FROM card_deck)", conn))
                    {

                        SqlDataReader reader = cmd2.ExecuteReader();
                        while (reader.Read())
                        {
                            Card card = RowToObject(reader);
                            output.Add(card);
                        }
                    }
                }

          
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return output;
        }
    }
}
