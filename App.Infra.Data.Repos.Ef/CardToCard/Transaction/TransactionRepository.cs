using App.Domain.Core.CardToCard.DTOs;
using App.Domain.Core.CardToCard.Transaction.Data.Repository;
using App.Domain.Core.CardToCard.Transaction.Entity;
using App.Infra.Data.Db.SqlServer.Ef.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.CardToCard;

namespace App.Infra.Data.Repos.Ef.CardToCard.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _appDbContext;
        public TransactionRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public void AddTransaction(Transactionn transactionn)
        {
            
            try
            {
                var tran = _appDbContext.Transactionns.Add(transactionn);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public float DailyTransAction(string cardNumber)
        {
            try
            {


                var amountOfTransaction = _appDbContext.Transactionns
                    .Where(x => x.AtTime.Date == DateTime.Now.Date && x.SourceCard.CardNumber == cardNumber)
                    .Sum(x => x.Amount);
                return amountOfTransaction;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public float GetAmount(int amount)
        {

            try
            {
                _appDbContext.Transactionns.FirstOrDefault(x => x.Amount == amount);

                return amount;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GetTransactionDto> GetListOfTransaction(string cardNumber)
        {
            try
            {
                return _appDbContext.Transactionns.Where(x => x.SourceCard.CardNumber == cardNumber || x.DestinationCard.CardNumber == cardNumber)
                    .Select(x => new GetTransactionDto
                    {
                        SourceCardNumber = x.SourceCard.CardNumber,
                        DestinationsCardNumber = x.DestinationCard.CardNumber,
                        AtTime = x.AtTime,
                        Amount = x.Amount,
                        IsSuccess = x.IsSuccess,


                    }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
        


