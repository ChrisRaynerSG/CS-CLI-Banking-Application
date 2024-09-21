using BankingAppDotNet.database_management;
using BankingAppDotNet.services;
using BankingAppDotNet.user_interface;
using MySql.Data.MySqlClient;

namespace BankingAppDotNet.core;

public class AccountsScreenLogic : ConsoleScreen
{
    private AccountService accountService;

    public AccountsScreenLogic()
    {
        accountService = new AccountService();
    }
    
    public void doAccountsScreenPath()
    {
        if (accountService.DoesUserHaveAccounts(ProgramController.loggedInUser))
        {
            accountService.GetAllAccounts(ProgramController.loggedInUser);
        }
        else
        {
            PrintDisplay($"Welcome {ProgramController.loggedInUser.FirstName} {ProgramController.loggedInUser.LastName}","You currently have no active accounts with us.","Set up new account (S)", "Go back (B)");
            string userInput = Console.ReadKey().ToString().ToLower();
            while (!userInput.ToLower().Equals("b") && !userInput.ToLower().Equals("s"))
            {
                userInput = Console.ReadKey().ToString().ToLower();
            }

            if (!userInput.Equals("s"))
            {
                //todo create new account
            }
        }
    }
}