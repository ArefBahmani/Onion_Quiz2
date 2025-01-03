using App.Domain.Core.CardToCard.Card.Entity;
using App.Domain.Core.CardToCard.Card.Service;
using App.Domain.Service.Card;
using App.Infra.Data.Db.SqlServer.Ef.Db;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.MVC.Quiz2.Controllers
{
    public class CardController : Controller
    {
      
        private readonly ICardServices cardService;
        string cardNumber = OnlineUser.Online;
        public CardController(ICardServices cardServices)
        {
            cardService = cardServices;
        }
        public IActionResult Changepass()
        {
            if (OnlineUser.Online == null)
            {
                return Redirect("/Login/Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult ChangePass(string oldPass, string newPass)
        {
            if (OnlineUser.Online == null)
            {
                return Redirect("/Login/Login");
            }
            string cardNumber = OnlineUser.Online;
            cardService.ChangePass(cardNumber, oldPass, newPass);
            return Redirect("/Login/Login");

        }
        

        public IActionResult ShowBalance()
        {
            if (OnlineUser.Online == null)
            {
                return Redirect("/Login/Login");
            }
            var balanceValue = cardService.ShowBalanceUser(cardNumber);
            var card = new Card
            {
                Balance = balanceValue 
            };
            return View("ShowBalance", card);
        }




    }
}
