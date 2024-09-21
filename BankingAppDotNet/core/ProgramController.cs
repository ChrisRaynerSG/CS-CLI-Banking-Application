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

    public bool RunApplication()
    {
        
        //todo rewrite these as separate methods with return types to allow for easier navigation through the application

        // handle connection to database 
        
        // if (WelcomeScreen() == "success")
        // {
        //     
        // }
        // else
        // {
        //     return false;
        // }
        
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
                    //todo store logged in user in memory
                    //todo login to return a UserDto
                }
            }
            else if (response.ToLower() == "r")
            {
                RegisterService register = new RegisterService();
                response = register.Register();
                //todo store newly registered user in memory
                //todo register to return a UserDto
            }
        }
        if (response.ToLower() == "q")
        {
            return false;
        }
        ui.PrintDisplay("Please select one of the following options", "View Accounts (A)", "View Cards (C)", "Make a transaction (T)", "Update Information (U)", "Quit application (Q)");
        Console.Write("Selection: ");
        response = Console.ReadLine();
        while (response.ToLower() != "q")
        {
            //todo other things
        }
        if (response.ToLower() == "q")
        {
            return false;
        }
        return true;
    }
}

//todo program flow 
/*
 * Connect to database with user provided credentials
 * Welcome screen with options to Login or Register
 * Logged in screen 
 *
 *
 *
 *
 *
 * */