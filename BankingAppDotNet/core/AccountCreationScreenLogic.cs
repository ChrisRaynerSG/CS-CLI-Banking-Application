using System.Collections;
using BankingAppDotNet.services;
using BankingAppDotNet.user_interface;

namespace BankingAppDotNet.core;

public class AccountCreationScreenLogic : ConsoleScreen
{
    AccountService accountService;
    
    public AccountCreationScreenLogic()
    {
        accountService = new AccountService();
    }

    public void createNewAccountPath()
    {
        ArrayList banks = accountService.GetAllBanks();
        
    }
    
}