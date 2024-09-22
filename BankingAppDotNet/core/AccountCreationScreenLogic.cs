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
            string selection = (i%5 +1).ToString();
            display = UserInterfaceComponents.GetBankTableRowString($"({selection})",$"{bank.bankName}",$"{bank.bankCode}",$"{bank.address1}", $"{bank.address2}", $"{bank.address3}", $"{bank.city}");
            output.Add(display);
        }
        
        int numberOfPages = Convert.ToInt32(Math.Ceiling((double)banks.Count / 5));
        int numberOfBanksOnLastPage = banks.Count % 5;
        int currentPage = 1;

        PrintDisplay("Please select a bank: ",output[0], output[1], output[2], output[3], output[4], output[5], "Go back (B) | Next page (N)");
        string userInput = Console.ReadKey().KeyChar.ToString().ToLower();
        while (userInput.ToLower() != "b" && userInput.ToLower() != "n" && userInput.ToLower() != "1" &&
               userInput.ToLower() != "2" && userInput.ToLower() != "3" && userInput.ToLower() != "4" &&
               userInput.ToLower() != "5")
        {
            userInput = Console.ReadKey().KeyChar.ToString().ToLower();
        }

        while (userInput.ToLower() != "b")
        {
            if (userInput.ToLower() == "n")
            {
                currentPage++;
                if (currentPage == numberOfPages)
                {
                    //todo logic to determine how many banks to display based on number of banks on last page
                    if (numberOfBanksOnLastPage == 1)
                    {
                        PrintDisplay("Please select a bank: ",output[0], output[(numberOfPages-1)*5+1], "", "", "", "", "Go back (B) | Previous page (P)");
                        userInput = Console.ReadKey().KeyChar.ToString().ToLower();
                        while (userInput.ToLower() != "b" && userInput.ToLower() != "p" && userInput.ToLower() != "1" &&
                               userInput.ToLower() != "2" && userInput.ToLower() != "3" && userInput.ToLower() != "4" &&
                               userInput.ToLower() != "5")
                        {
                            userInput = Console.ReadKey().KeyChar.ToString().ToLower();
                        }

                        if (userInput.ToLower() == "p")
                        {
                            currentPage--;
                            PrintDisplay("Please select a bank: ",output[0], output[currentPage*5], output[2], output[3], output[4], output[5], "Go back (B) | Next page (N)");
                            userInput = Console.ReadKey().KeyChar.ToString().ToLower();
                        }
                    }
                    else if (numberOfBanksOnLastPage == 2)
                    {
                        PrintDisplay("Please select a bank: ",output[0], output[numberOfPages*5], output[numberOfPages*5+1], "", "", "", "Go back (B) | Previous page (P)");
                        userInput = Console.ReadKey().KeyChar.ToString().ToLower();
                    }
                    else if (numberOfBanksOnLastPage == 3)
                    {
                        PrintDisplay("Please select a bank: ",output[0], output[numberOfPages*5], output[numberOfPages*5+1], output[numberOfPages*5+2], "", "", "Go back (B) | Previous page (P)");
                        userInput = Console.ReadKey().KeyChar.ToString().ToLower();
                    }
                    else if (numberOfBanksOnLastPage == 2)
                    {
                        PrintDisplay("Please select a bank: ",output[0], output[numberOfPages*5], output[numberOfPages*5+1], output[numberOfPages*5+2], output[numberOfPages*5+3], "", "Go back (B) | Previous page (P)");
                        userInput = Console.ReadKey().KeyChar.ToString().ToLower();
                    }
                    else
                    {
                        PrintDisplay("Please select a bank: ",output[0], output[numberOfPages*5], output[numberOfPages*5+1], output[numberOfPages*5+2], output[numberOfPages*5+3], output[numberOfPages*5+4], "Go back (B) | Previous page (P)");
                        userInput = Console.ReadKey().KeyChar.ToString().ToLower();
                    }
                   
                }
                else
                {
                    PrintDisplay("Please select a bank: ",output[0], output[1], output[2], output[3], output[4], output[5], "Go back (B) | Next page (N) | Previous page (P)");
                }
            }
        }



        //todo display 5 banks per page, have option to go to next page (if not last), or back a page (if not first), and to select any of the banks on the page
        //todo example page: | Selection | Bank Name | Sort Code | Address 1 | Address 2 | Address 3 |   City   |
        //todo               |    (1)    | Barcwest  | 20-12-25  |    15     | The Road  |   Ville   |  Vilton  |
        //todo               |    (2)    | Barcwest  | 20-22-25  |    16     | The Road  |   Villp   |  Vilton  |


    }
    
}