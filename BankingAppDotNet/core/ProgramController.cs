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
        string response = "n";
        while (response.ToLower() != "q")
        {
            ui.PrintDisplay("Please select an option from the list below:", "Login (L)", "Register (R)", "Quit application (Q)");
            Console.WriteLine("Selection: ");
            response = Console.ReadLine();
            
        }
        Program.IsRunning = false;
    }
    
    
    
}