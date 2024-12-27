using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CardToCard.DTOs
{
    public class GetTransactionDto
    {
        public string SourceCardNumber { get; set; }
        public string DestinationsCardNumber { get; set; }
        public DateTime AtTime { get; set; }
        public float Amount { get; set; }
        public bool IsSuccess { get; set; }
    }
}
