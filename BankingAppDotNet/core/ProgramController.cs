﻿using BankingAppDotNet.services;
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
                }
            }
            else if (response.ToLower() == "r")
            {
                RegisterService register = new RegisterService();
                response = register.Register();
                //todo registration logic
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