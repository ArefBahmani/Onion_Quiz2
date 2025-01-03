using App.Domain.Core.CardToCard.Card.Entity;
using App.Domain.Core.CardToCard.Transaction.Service;
using App.Infra.Data.Db.SqlServer.Ef.Db;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.MVC.Quiz2.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService _transaction)
        {
            _transactionService = _transaction;
        }
        string cardNumber = OnlineUser.Online;
        
        public IActionResult Transactions()
        {
            if (OnlineUser.Online == null)
            {
                return Redirect("/Login/Login");
            }
            var list = _transactionService.ShowList(cardNumber);

            return View("Transactions", list);
        }
        
        //public IActionResult List()
        //{
        //    if (OnlineUser.Online == null)
        //    {
        //        return Redirect("/Login/Login");
        //    }
        //    var list = _transactionService.ShowList(cardNumber);
            
        //    return View("Transactions",list);
        //}
        
      
        

    }

}
