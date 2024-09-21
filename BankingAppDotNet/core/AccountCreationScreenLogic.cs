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
                $"({i + 1})|{bank.bankName}|{bank.bankCode}|{bank.address1}|{bank.address2}|{bank.address3}|{bank.city}"; // needs formatting
            output.Add(display);
        }
        int numberOfPages = Convert.ToInt32(Math.Ceiling((double)banks.Count / 5));

        
        
        //todo display 5 banks per page, have option to go to next page (if not last), or back a page (if not first), and to select any of the banks on the page
        //todo example page: | Selection | Bank Name | Sort Code | Address 1 | Address 2 | Address 3 |   City   |
        //todo               |    (1)    | Barcwest  | 20-12-25  |    15     | The Road  |   Ville   |  Vilton  |
        //todo               |    (2)    | Barcwest  | 20-22-25  |    16     | The Road  |   Villp   |  Vilton  |
        
        
    }
    
}