using App.Domain.Core.CardToCard.Card.Service;
using App.Domain.Core.CardToCard.DTOs;
using App.Domain.Core.CardToCard.Transaction.AppService;
using App.Domain.Core.CardToCard.Transaction.Service;
using App.Domain.Core.CardToCard.User;
using App.Domain.Service.Card;
using App.Domain.Service.Transaction;
using App.Domain.Service.User;
using Colors.Net;
using Colors.Net.StringColorExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.CardToCard.Transaction
{
    public class TransactionAppService : ITransactionAppService
    {
        private  readonly ITransactionService _transactionService;
        private readonly IUserService _userService;
        private readonly ICardServices _cardService;
        public TransactionAppService(ITransactionService transactionService, IUserService userService, ICardServices cardServices)
        {
            _transactionService = transactionService;
            _userService = userService;
            _cardService = cardServices;
        }
        public void Transfer(string sourceCardNumber)
        {
            
            Console.Write("Please Insert Destination CardNumber : ");
            var destinationCardNumber = Console.ReadLine();

            Console.Write("Amount : ");
            var amount = int.Parse(Console.ReadLine());
            var result = _transactionService.ShowInformation(destinationCardNumber, amount);
            ColoredConsole.WriteLine(result.Yellow());
            Console.WriteLine("do you want finish?   (y/n)");
            var input = Console.ReadLine();
            switch (input)
            {
                case "y":

                    var userid = _cardService.GetUserIdByCardNumber(sourceCardNumber);
                    var pass = _userService.GenerateVerificationCode(userid.UserId, userid.HolderName);

                    Console.WriteLine("Enter TwoFactory password");
                    int twofac = Convert.ToInt32(Console.ReadLine());

                    _userService.ValidateVerificationCode(userid.UserId, userid.HolderName, twofac);



                    var transactionStatus = _transactionService.TransferMoney(sourceCardNumber, destinationCardNumber, amount);
                    ColoredConsole.WriteLine(transactionStatus.Green());

                    break;
                case "n":


                    break;
            }


        }
       
    }
}
