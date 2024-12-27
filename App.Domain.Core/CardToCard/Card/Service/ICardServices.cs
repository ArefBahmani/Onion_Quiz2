using App.Domain.Core.CardToCard.Card.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CardToCard.Card.Service
{
    public interface ICardServices
    {
        CardToCard.Result.Result PasswordIsValid(string cardNumber, string password);
        Entity.Card GetUserIdByCardNumber(string cardNumber);
        float ShowBalanceUser(string cardNumber);
        void ChangePass(string cardNumber, string oldpassword, string newpassword);

    }
}
