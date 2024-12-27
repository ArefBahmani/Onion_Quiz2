using App.Domain.Core.CardToCard.DTOs;
using App.Domain.Core.CardToCard.Transaction.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CardToCard.Transaction.Data.Repository
{
    public interface ITransactionRepository
    {
        List<GetTransactionDto> GetListOfTransaction(string cardNumber);
        float DailyTransAction(string cardNumber);
        void AddTransaction(Transactionn transactionn);
        float GetAmount(int amount);
    }
}
