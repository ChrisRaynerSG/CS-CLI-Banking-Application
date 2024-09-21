using BankingAppDotNet.services;
using BankingAppDotNet.user_interface;

namespace BankingAppDotNet.core;

public class WelcomeScreenLogic : ConsoleScreen
{
    private RegisterService register;
    private LoginService login;

    public WelcomeScreenLogic()
    {
        register = new RegisterService();
        login = new LoginService();
    }

public bool doWelcomeScreenPath()
    {
        string response = "n";
        while (response.ToLower() != "q" && response != "success")
        {
            PrintDisplay("Please select an option from the list below:", "Login (L)", "Register (R)", "Quit application (Q)");
            Console.Write("Selection: ");
            response = Console.ReadLine();
            if (response.ToLower() == "l")
            {
                if (login.Login() == "success")
                {
                    // response = "success";
                    return true;
                    //todo store logged in user in memory
                    //todo login to return a UserDto
                }
            }
            else if (response.ToLower() == "r")
            {
                if (register.Register() == "registered")
                {
                    //todo store newly registered user in memory
                    //todo register to return a UserDto
                    return true;
                }
            }
        }
        if (response.ToLower() == "q")
        {
            return false;
        }

        return true;
    }
}