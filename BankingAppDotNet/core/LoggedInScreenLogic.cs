using BankingAppDotNet.dtos;
using BankingAppDotNet.user_interface;

namespace BankingAppDotNet.core;

public class LoggedInScreenLogic : ConsoleScreen
{

    public bool doLoggedInScreenPath(UserDto user)
    {
        PrintDisplay($"Welcome {user.FirstName} {user.LastName}!", "Please select one of the following options below:", "View accounts (A)", "View cards (C)","Make a transaction (T)", "Update information (U)", "Quit application (Q)");
        string userInput = Console.ReadKey().KeyChar.ToString().ToLower();

        while (userInput != "q" && userInput != "a" && userInput != "c" && userInput != "u" && userInput != "t")
        {
            userInput = Console.ReadKey().KeyChar.ToString().ToLower();
        }

        while (userInput != "a" && userInput != "c" && userInput != "u" && userInput != "t")
        {
            
        }
        return false;
    }
}