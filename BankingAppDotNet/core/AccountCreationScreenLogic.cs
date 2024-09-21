using System.Collections;
using BankingAppDotNet.dtos;
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
        List<string> output = new List<string>();

        for(int i = 0; i < banks.Count; i++)
        {
            BankDto bank = (BankDto)banks[i];
            string display =
                $"({i + 1})|{bank.bankName}|{bank.bankCode}|{bank.address1}|{bank.address2}|{bank.address3}|{bank.city}";
            output.Add(display);
        }
        int numberOfPages = Convert.ToInt32(Math.Ceiling((double)banks.Count / 5));
    }
    
}