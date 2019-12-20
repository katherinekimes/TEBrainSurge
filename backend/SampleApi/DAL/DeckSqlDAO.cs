using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TEFlashCards.Models;

namespace TEFlashCards.DAL
{
    public class DeckSqlDAO : IDeckDAO
    {
        private readonly string connectionString;

        /// <summary>
        /// Creates a new sql dao for deck objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public DeckSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        /// <summary>
        /// Gets the deck from the database.
        /// </summary>
        /// <param name="deckId"></param>
        /// <returns></returns>
        public Deck GetDeck(int deckId)
        {
            Deck deck = new Deck(); 
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Deck WHERE deckId = @deckId;", conn);
                    cmd.Parameters.AddWithValue("@deckId", deckId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        deck = RowToObject(reader);
                    }
                }

                return deck;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Create new deck
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="userId"></param>
        public void CreateDeck(Deck deck, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Deck(UserId, DeckName, DeckDescription) VALUES(@userId, @deckname, @deckDescription)", conn);
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@deckname", deck.DeckName);
                    cmd.Parameters.AddWithValue("@deckDescription", deck.DeckDescription);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private Deck RowToObject(SqlDataReader reader)
        {
            return new Deck()
            {
                DeckName = Convert.ToString(reader["DeckName"]),
                DeckId = Convert.ToInt32(reader["DeckId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                DeckDescription = Convert.ToString(reader["DeckDescription"])
            };
        }

        public IList<Deck> GetAllDecks()
        {
            List<Deck> output = new List<Deck>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT * FROM Deck";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Deck deck = RowToObject(reader);
                        output.Add(deck);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return output;

        }

        public bool DeleteDeck(int deckId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Deck WHERE deckId = @deckId", conn);
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

        public bool ModifyDeck(Deck updatedDeck)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE Deck SET DeckName = @updatedDeckName, DeckDescription = @updatedDeckDescription WHERE DeckId = @deckId", conn);
                    cmd.Parameters.AddWithValue("@updatedDeckName", updatedDeck.DeckName);
                    cmd.Parameters.AddWithValue("@updatedDeckDescription", updatedDeck.DeckDescription);
                    cmd.Parameters.AddWithValue("@deckId", updatedDeck.DeckId);

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
