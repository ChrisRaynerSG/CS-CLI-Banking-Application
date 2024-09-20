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
        while (response.ToLower() != "q")
        {
            ui.PrintDisplay("Please select an option from the list below:", "Login (L)", "Register (R)", "Quit application (Q)");
            Console.WriteLine("Selection: ");
            login.Login("chrisray2712@gmail.com", "Password@1");
            response = Console.ReadLine();
            
        }
        Program.IsRunning = false;
    }
    
    
    
}