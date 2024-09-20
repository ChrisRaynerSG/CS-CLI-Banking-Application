using BankingAppDotNet.services;
using BankingAppDotNet.user_interface;

namespace BankingAppDotNet.core;

public class ProgramController
{
    private ConsoleScreen ui;
    
    public ProgramController()
    {
        ui = new ConsoleScreen();
    }

    public void RunApplication()
    {
        LoginService login = new LoginService();
        
        string response = "n";
        while (response.ToLower() != "q" && response != "success")
        {
            ui.PrintDisplay("Please select an option from the list below:", "Login (L)", "Register (R)", "Quit application (Q)");
            Console.Write("Selection: ");
            response = Console.ReadLine();
            if (response.ToLower() == "l")
            {
                if (login.Login() == "success")
                {
                    response = "success";
                    break;
                }
            }
            Console.Write("Selection:");
            response = Console.ReadLine();
            
        }
        if (response.ToLower() == "q")
        {
            Program.IsRunning = false;
        }
    }
}