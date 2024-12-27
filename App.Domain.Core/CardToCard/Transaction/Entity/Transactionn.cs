using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CardToCard.Card.Entity;
namespace App.Domain.Core.CardToCard.Transaction.Entity

{
    public class Transactionn
    {
        public int TransactionId { get; set; }
        public int SourceCardid { get; set; }
        public int DestinationCardid { get; set; }
        public DateTime AtTime { get; set; }
        public float Amount { get; set; }
        public bool IsSuccess { get; set; }

        public Card.Entity.Card SourceCard { get; set; }
        public Card.Entity.Card DestinationCard { get; set; }
    }
}
