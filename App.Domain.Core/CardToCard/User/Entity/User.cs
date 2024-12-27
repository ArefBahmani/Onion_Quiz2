using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CardToCard.User.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string Code { get; set; }
        public DateTime DateTimeAdd { get; set; }

        public List<CardToCard.Card.Entity.Card> Cards { get; set; }
    }
}
