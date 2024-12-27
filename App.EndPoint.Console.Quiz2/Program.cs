
using App.Domain.Core.CardToCard.Card.Service;
using App.Domain.Core.CardToCard.DTOs;
using App.Domain.Core.CardToCard.Result;
using App.Domain.Core.CardToCard.User;
using App.Domain.Service.Card;
using App.Domain.Service.Transaction;
using App.Domain.Service.User;
using Colors.Net;
using Colors.Net.StringColorExtensions;
using ConsoleTables;

ICardServices _cardService = new CardService();
TransactionService _transactionService = new TransactionService();
IUserService _userService = new UserService();
string cardNumber;
Result passwordValidation;
try
{
    do
    {
        Console.Clear();

        Console.Write("CardNumber : ");
        cardNumber = Console.ReadLine();

        Console.Write("Password : ");
        string password = Console.ReadLine();

        passwordValidation = _cardService.PasswordIsValid(cardNumber, password);

        Console.WriteLine(passwordValidation.Massage);
        Console.ReadKey();

    } while (!passwordValidation.IsSuccess);


    bool menu = true;
    while (menu)
    {
        Console.Clear();

        ColoredConsole.WriteLine("1.Transfer Money".DarkGreen());
        ColoredConsole.WriteLine("-----------------------------------------------------------------".Blue());
        Console.WriteLine("");
        ColoredConsole.WriteLine("2.Show Transactions".DarkGreen());
        ColoredConsole.WriteLine("-----------------------------------------------------------------".Blue());
        Console.WriteLine("");
        ColoredConsole.WriteLine("3.Show Balance".DarkGreen());
        ColoredConsole.WriteLine("-----------------------------------------------------------------".Blue());
        Console.WriteLine("");
        ColoredConsole.WriteLine("4.Change Password".DarkGreen());
        ColoredConsole.WriteLine("-----------------------------------------------------------------".Blue());
        Console.WriteLine("");
        ColoredConsole.WriteLine("5.Exit Program".DarkRed());

        var selectedItem = Console.ReadKey();

        Console.Clear();

        var sourceCardNumber = cardNumber;

        ColoredConsole.WriteLine($"Source CardNumber Is {cardNumber} ".Magenta());
        Console.WriteLine();

        switch (selectedItem.KeyChar)
        {
            case '1':
                {
                    Transfer(sourceCardNumber);
                    break;
                }
            case '2':
                {
                    ShowListOfTransactions();
                    break;
                }
            case '3':

                var balance = _cardService.ShowBalanceUser(sourceCardNumber);
                Console.Write($"balance {balance}$");
                Console.ReadKey();

                break;
            case '4':
                Console.WriteLine("Please Enter oldpassword");
                string oldpass = Console.ReadLine();
                Console.WriteLine("Please enter newpassword");
                string newpass = Console.ReadLine();
                _cardService.ChangePass(sourceCardNumber, oldpass, newpass);
                Console.ReadKey();

                break;
            case '5':
                do
                {
                    Console.Clear();

                    Console.Write("CardNumber : ");
                    cardNumber = Console.ReadLine();

                    Console.Write("Password : ");
                    var password = Console.ReadLine();

                    passwordValidation = _cardService.PasswordIsValid(cardNumber, password);

                    Console.WriteLine(passwordValidation.Massage);
                    Console.ReadKey();

                } while (!passwordValidation.IsSuccess);


                break;


        }
    }


    void Transfer(string sourceCardNumber)
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





        Console.ReadKey();
    }
    void ShowListOfTransactions()
    {
        var transactions = _transactionService.ShowList(cardNumber);

        ConsoleTable
            .From<GetTransactionDto>(transactions)
            .Configure(o => o.NumberAlignment = Alignment.Right)
            .Write(ConsoleTables.Format.Minimal);

        Console.ReadKey();
    }
}
catch (FormatException ex)
{
    Console.WriteLine($"Error Formating: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected Error: {ex.Message}");
    Console.ReadKey();
}
