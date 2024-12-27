using App.Domain.Core.CardToCard.Card.Data.Repository;
using App.Domain.Core.CardToCard.Card.Service;
using App.Domain.Core.CardToCard.Result;
using App.Infra.Data.Repos.Ef.CardToCard.Card;
using Colors.Net;
using Colors.Net.StringColorExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.Card
{
    public class CardService : ICardServices
    {
        private readonly ICardRepository _cardRepository;
        public CardService()
        {
            _cardRepository = new CardRepository();
        }
        public void ChangePass(string cardNumber, string oldpassword, string newpassword)
        {
            try
            {
                var card = _cardRepository.GetCardBy(cardNumber);
                if (oldpassword != card.Password)
                {
                    ColoredConsole.WriteLine("Password is not correct".Red());
                }
                _cardRepository.Changepassword(card.CardNumber, oldpassword, newpassword);
                ColoredConsole.WriteLine("Change Successfully".Green());
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Core.CardToCard.Card.Entity.Card GetUserIdByCardNumber(string cardNumber)
        {
            try
            {
                var card = _cardRepository.GetCardBy(cardNumber);

                return card;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Result PasswordIsValid(string cardNumber, string password)
        {
            try
            {
                var tryCount = _cardRepository.GetCardBy(cardNumber);
                if (tryCount.FalsePassword == 3)
                    return new Result() { IsSuccess = false, Massage = " Your Card is Blocked Beacuse You Over 3 time Trying Wrong Password " };
                var passwordIsvalid = _cardRepository.IsValidPassword(cardNumber, password);
                if (passwordIsvalid == false)
                {
                    _cardRepository.SetWrongPassword(cardNumber);
                    return new Result() { IsSuccess = false, Massage = "card Number Or Password Is Wrong..." };
                }
                else
                {
                    return new Result() { IsSuccess = true, Massage = "Wellcome" };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public float ShowBalanceUser(string cardNumber)
        {
            try
            {
                var user = _cardRepository.GetBalance(cardNumber);
                if (user == null)
                {
                    throw new Exception("Error in Show Balance ");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
