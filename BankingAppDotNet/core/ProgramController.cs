using BankingAppDotNet.database_management;
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
        while(!DatabaseConfigSetup.VerifyConfigJson()){
            
            PrintDatabaseSetup("Enter server URL");
            Console.Write("Server URL: ");
            string serverURL = Console.ReadLine();
            PrintDatabaseSetup("Enter server port");
            Console.Write("Server port: ");
            string serverPort = Console.ReadLine();
            PrintDatabaseSetup("Enter database name/schema");
            Console.Write("Database name: ");
            string databaseName = Console.ReadLine();
            PrintDatabaseSetup("Enter database username");
            Console.Write("Database username: ");
            string username = Console.ReadLine();
            PrintDatabaseSetup("Enter database password");
            Console.Write("Database password: ");
            string password = Console.ReadLine();
            
            DatabaseConfigSetup.WriteConfigJson(serverURL, serverPort, databaseName, username, password);
        }
        
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

    private void PrintDatabaseSetup(string message)
    {
        ui.PrintDisplay("It looks like you are performing first time setup.", "Please follow the instructions below.", message);
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