using App.Domain.Core.CardToCard.Card.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.CardToCard.Card.Data.Repository
{
    public interface ICardRepository
    {
        bool IsValidPassword(string cardNumber, string password);
        void WithDrow(string cardNumber, float amount);
        void Diposit(string cardNumber, float amount);
        void SetWrongPassword(string cardNumber);
        int GetWrongPasswordTrys(string cardNumber);
        bool IsActiveCard(string cardNumber);
        Entity.Card GetCardBy(string cardNumber);
        public void Changepassword(string cardNumber, string oldpassword, string newpassword);
        public float GetBalance(string cardNumber);
        public void SaveChanges();

    }
}
