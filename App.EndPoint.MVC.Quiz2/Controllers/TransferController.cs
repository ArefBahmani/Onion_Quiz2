using App.Domain.Core.CardToCard.Card.Service;
using App.Domain.Core.CardToCard.Transaction.Service;
using App.Domain.Core.CardToCard.User;
using App.Domain.Core.CardToCard.User.Data.Repository;
using App.Infra.Data.Db.SqlServer.Ef.Db;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.MVC.Quiz2.Controllers
{
    public class TransferController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICardServices _cardServices;
        private readonly ITransactionService _transactionService;
       public TransferController(IUserService userService, ICardServices cardServices, ITransactionService transactionService)
        {
            _userService = userService;
            _cardServices = cardServices;
            _transactionService = transactionService;
        }
        public IActionResult Index()
        {
            if (OnlineUser.Online == null)
            {
                return Redirect("/Login/Login");
            }
            return View();
        }
        public IActionResult TwoFactorCode(string cardNumber , float amount)
        {
           OnlineUser.DesteniCard = cardNumber;
            OnlineUser.Amount = amount;
            OnlineUser.Code = _userService.CodeRandom();
            return Redirect("/Transfer/Finish");

        }
        public IActionResult Finish()
        {
          
            return View(OnlineUser.OnlineCard);
        }
        [HttpPost]
        public IActionResult CardToCard(string code)
        {
            if (code != OnlineUser.Code)
            {
                TempData["Message"] = "Something is Wrong";
                TempData["AlertType"] = "danger";
                return Redirect("Transfer/Finish");
            }
            _transactionService.TransferMoney(OnlineUser.Online,OnlineUser.DesteniCard,OnlineUser.Amount);
            return Redirect("/Transaction/Transactions");

        }

    }
}
