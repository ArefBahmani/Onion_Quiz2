using App.Domain.Core.CardToCard.Card.Service;
using App.Domain.Core.CardToCard.User;
using App.Domain.Service.Card;
using App.Domain.Service.User;
using App.Infra.Data.Db.SqlServer.Ef.Db;
using App.Infra.Data.Repos.Ef.CardToCard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace App.EndPoint.MVC.Quiz2.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICardServices cardServices;
        
        public LoginController(ICardServices CardService)
        {
            cardServices = CardService;
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string cardNumber,string password)
        {
            var card = cardServices.PasswordIsValid(cardNumber, password);

            if (card.IsSuccess)
            {
              
            TempData["Message"] = "You are Login";
            TempData["AlertType"] = "Success";
            }
            else
            {
                TempData["Message"] = "CardNumber or Password is NotValid ";
                TempData["AlertType"] = "danger";
            }
                

            return View();
        }
        public ActionResult LogOut()
        {
            OnlineUser.Online = null;
            return Redirect("/Login/Login");
        }
    }
}
