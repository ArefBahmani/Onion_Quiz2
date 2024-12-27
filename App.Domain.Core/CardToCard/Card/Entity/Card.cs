using App.Domain.Core.CardToCard.Transaction.Entity;
using App.Domain.Core.CardToCard.User.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using App.Domain.Core.CardToCard.Transaction.Entity;

namespace App.Domain.Core.CardToCard.Card.Entity
{
    public class Card
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public string HolderName { get; set; }

        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public float Balance { get; set; }
        public int FalsePassword { get; set; } = 0;
        public List<Transactionn> TransactionnsAsSource { get; set; }
        public List<Transactionn> TransactionnsAsDestination { get; set; }
        public CardToCard.User.Entity.User User { get; set; }
        public int UserId { get; set; }
    }
}
