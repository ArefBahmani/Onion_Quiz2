using App.Domain.Core.CardToCard.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CardToCard.Transaction.Service
{
    public interface ITransactionService
    {
        string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount);
        List<GetTransactionDto> ShowList(string cardNumber);
        string CalculateFee(int amount, string cardNumber, string destinationCard);
        string ShowInformation(string cardNumber, int amount);
    }
}
