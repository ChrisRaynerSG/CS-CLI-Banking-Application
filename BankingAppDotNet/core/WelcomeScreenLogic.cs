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
            response = Console.ReadKey().KeyChar.ToString().ToLower();
            if (response.ToLower() == "l")
            {
                if (login.Login() == "success")
                {
                    return true;
                }
            }
            else if (response.ToLower() == "r")
            {
                if (register.Register() == "registered")
                {
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