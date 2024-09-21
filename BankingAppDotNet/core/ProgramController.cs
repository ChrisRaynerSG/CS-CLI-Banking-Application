using BankingAppDotNet.database_management;
using BankingAppDotNet.services;
using BankingAppDotNet.user_interface;

namespace BankingAppDotNet.core;

public class ProgramController
{
    
    private ProgramLogic pl;
    
    public ProgramController()
    {
        pl = new ProgramLogic();
    }

    public bool RunApplication()
    {
        if (pl.doDatabaseSetupPath() == false)
        {
            return false;
        }

        if (pl.doWelcomeScreenPath() == false)
        {
            return false;
        }
        
        // ui.PrintDisplay("Please select one of the following options", "View Accounts (A)", "View Cards (C)", "Make a transaction (T)", "Update Information (U)", "Quit application (Q)");
        // Console.Write("Selection: ");
        // response = Console.ReadLine();
        // while (response.ToLower() != "q")
        // {
        //     //todo other things
        // }
        // if (response.ToLower() == "q")
        // {
        //     return false;
        // }
        return false;
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