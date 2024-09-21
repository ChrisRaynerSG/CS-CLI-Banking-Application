using BankingAppDotNet.dtos;
using BankingAppDotNet.user_interface;

namespace BankingAppDotNet.core;

public class LoggedInScreenLogic : ConsoleScreen
{

    private AccountsScreenLogic accountsScreenLogic;
    private string userInput;

    public LoggedInScreenLogic()
    {
        accountsScreenLogic = new AccountsScreenLogic();
    }

    public bool doLoggedInScreenPath()
    {
        
        ValidateUserInput();
        
        while (userInput != "q")
        {
            if (userInput == "a")
            {
                //todo accounts page
                accountsScreenLogic.doAccountsScreenPath();
                userInput = "n";
            }

            else if (userInput == "c")
            {
                //todo cards page
                userInput = "n";
            }

            else if(userInput == "t")
            {
                //todo transactions page
                userInput = "n";
            }
            else if (userInput == "u")
            {
                //todo update information page
                userInput = "n";
            }
            else
            {
                ValidateUserInput();
            }
        }
        return false;
    }

    private void ValidateUserInput()
    {
        PrintLoggedInScreen();
        userInput = Console.ReadKey().KeyChar.ToString().ToLower();

        while (userInput != "q" && userInput != "a" && userInput != "c" && userInput != "u" && userInput != "t")
        {
            PrintLoggedInScreen();
            userInput = Console.ReadKey().KeyChar.ToString().ToLower();
        }
    }

    private void PrintLoggedInScreen()
    {
        PrintDisplay($"Welcome {ProgramController.user.FirstName} {ProgramController.user.LastName}!", "Please select one of the following options below:", "View accounts (A)", "View cards (C)","Make a transaction (T)", "Update information (U)", "Quit application (Q)");
    }
}