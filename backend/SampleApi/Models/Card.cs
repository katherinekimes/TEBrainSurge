using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEFlashCards.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public string FrontText { get; set; }
        public string BackText { get; set; }
        public string Tags { get; set; }
        public string UserName { get; set; }

    }
}
