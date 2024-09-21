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


        string display = UserInterfaceComponents.GetBankTableRowString("Selection", "Bank Name", "Sort Code",
            "Address 1", "Address 2", "Address 3", "City");
        output.Add(display);
        
        for(int i = 0; i < banks.Count; i++)
        {
            BankDto bank = (BankDto)banks[i];
            display = UserInterfaceComponents.GetBankTableRowString($"{i + 1}",$"{bank.bankName}",$"{bank.bankCode}",$"{bank.address1}", $"{bank.address2}", $"{bank.address3}", $"{bank.city}");
            output.Add(display);
        }
        int numberOfPages = Convert.ToInt32(Math.Ceiling((double)banks.Count / 5));

        PrintDisplay(output[0], output[1], output[2], output[3], output[4], output[5]);
        string test = Console.ReadLine();



        //todo display 5 banks per page, have option to go to next page (if not last), or back a page (if not first), and to select any of the banks on the page
        //todo example page: | Selection | Bank Name | Sort Code | Address 1 | Address 2 | Address 3 |   City   |
        //todo               |    (1)    | Barcwest  | 20-12-25  |    15     | The Road  |   Ville   |  Vilton  |
        //todo               |    (2)    | Barcwest  | 20-22-25  |    16     | The Road  |   Villp   |  Vilton  |


    }
    
}