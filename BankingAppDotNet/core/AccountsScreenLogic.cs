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
        if (accountService.doesUserHaveAccounts(ProgramController.user))
        {
            
        }
        else
        {
            PrintDisplay($"Welcome {ProgramController.user.FirstName} {ProgramController.user.LastName}","You currently have no active accounts with us.","Set up new account (S)", "Go back (B)");
            string userInput = Console.ReadKey().ToString().ToLower();
        }
    }
}