using BankingAppDotNet.database_management;
using BankingAppDotNet.services;
using BankingAppDotNet.user_interface;
using MySql.Data.MySqlClient;

namespace BankingAppDotNet.core;

public class AccountsScreenLogic : ConsoleScreen
{
    private AccountService accountService;
    private AccountCreationScreenLogic accountCreationScreenLogic;

    public AccountsScreenLogic()
    {
        accountService = new AccountService();
        accountCreationScreenLogic = new AccountCreationScreenLogic();
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
            string userInput = Console.ReadKey().KeyChar.ToString().ToLower();
            while (userInput.ToLower()!="b" && userInput.ToLower() != "s")
            {
                userInput = Console.ReadKey().KeyChar.ToString().ToLower();
            }

            if (userInput == "s")
            {
                accountCreationScreenLogic.createNewAccountPath();
            }
        }
    }
}