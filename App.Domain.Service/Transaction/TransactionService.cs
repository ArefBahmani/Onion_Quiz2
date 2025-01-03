using App.Domain.Core.CardToCard.Card.Data.Repository;
using App.Domain.Core.CardToCard.DTOs;
using App.Domain.Core.CardToCard.Transaction.Data.Repository;
using App.Domain.Core.CardToCard.Transaction.Entity;
using App.Domain.Core.CardToCard.Transaction.Service;
using App.Infra.Data.Db.SqlServer.Ef.Db;
using App.Infra.Data.Repos.Ef.CardToCard.Card;
using App.Infra.Data.Repos.Ef.CardToCard.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICardRepository _cardRepository;
        public TransactionService(ITransactionRepository transactionRepository, ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
            _transactionRepository = transactionRepository;

        }
        public string CalculateFee(int amount, string cardNumber, string destinationCard)
        {
            try
            {
                var user = _cardRepository.GetCardBy(cardNumber);
                var user2 = _cardRepository.GetCardBy(destinationCard);
                const double highFeeRate = 0.015;
                const double lowFeeRate = 0.005;


                double fees = amount * lowFeeRate;
                double feem = amount * highFeeRate;
                if (destinationCard == null)
                {
                    return $"This card{destinationCard} does not exist.";
                }
                if (amount >= 1000)
                {
                    user.Balance -= (int)feem;
                    return $"You transferred over $1000. Fee: ${feem:F2}.";

                }
                user.Balance -= (int)fees;
                return $"You transferred under $1000. Fee: ${fees:F2}.";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ShowInformation(string cardNumber, int amount)
        {
            try
            {
                var card = _cardRepository.GetCardBy(cardNumber);
                if (card == null)
                {
                    return $"Destination card not found";
                }
                return $"Are you sure to Send {amount}$  --  In This Card -- {cardNumber}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GetTransactionDto> ShowList(string cardNumber)
        {
            try
            {
                var result = _transactionRepository.GetListOfTransaction(cardNumber);
                return result;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string TransferMoney(string sourceCardNumber, string destinationCardNumber, float amount)
        {
            var isSuccess = false;

            if (amount == 0)
                return "The transfer amount must be greater than 0 $ ";

            if (sourceCardNumber.Length < 16 || sourceCardNumber.Length > 16)
                return "sourceCardNumber is not valid";

            if (destinationCardNumber.Length < 16 || destinationCardNumber.Length > 16)
                return "sourceCardNumber is not valid";

            if (!_cardRepository.IsActiveCard(sourceCardNumber))
                return "sourceCardNumber is not valid";

            if (!_cardRepository.IsActiveCard(destinationCardNumber))
                return "destinationCardNumber is not valid";
            if (amount >= 1000)
            {
                var am = amount * 0.015f;

            }


            var sourceCard = _cardRepository.GetCardBy(sourceCardNumber);
            var destinationCard = _cardRepository.GetCardBy(destinationCardNumber);

            if (sourceCard.Balance < amount)
                return "your card doesn't have enough balance for this transaction";

            if ((_transactionRepository.DailyTransAction(sourceCardNumber) + amount) > 250)

                return "Your daily transfer limit is full";

            try
            {
                if (amount >= 1000)
                {
                    amount = amount * 0.015f + amount;
                    _cardRepository.WithDrow(sourceCardNumber, amount);
                    _cardRepository.Diposit(destinationCardNumber, amount);
                    _cardRepository.SaveChanges();
                    isSuccess = true;
                }
                else
                {
                    amount = amount * 0.005f + amount;
                    _cardRepository.WithDrow(sourceCardNumber, amount);
                    _cardRepository.Diposit(destinationCardNumber, amount);
                    _cardRepository.SaveChanges();
                    isSuccess = true;

                }


            }
            catch (Exception e)
            {
                isSuccess = false;
                return "Transfer money failed";
            }
            finally
            {
                var transaction = new Transactionn()
                {
                    SourceCardid = sourceCard.UserId,
                    DestinationCardid = destinationCard.UserId,
                    Amount = amount,
                    AtTime = DateTime.Now,
                    IsSuccess = isSuccess
                };

                _transactionRepository.AddTransaction(transaction);
            }
            return "The money transfer operation was successful";

        }
    }
}

