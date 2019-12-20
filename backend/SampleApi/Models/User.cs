using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEFlashCards.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The user's id.
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// The user's username.
        /// </summary>        
        public string UserName { get; set; }

        /// <summary>
        /// The user's password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The user's salt.
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// The user's role.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The user's Email address.
        /// </summary>
        public string Email { get; set; }


    }


}
