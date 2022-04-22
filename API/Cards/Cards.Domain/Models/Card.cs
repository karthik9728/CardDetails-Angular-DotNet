using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Domain.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public string CardHolderName { get; set; } 
        public string CardNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVC { get; set; }

    }
}
