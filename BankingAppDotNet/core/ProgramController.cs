using BankingAppDotNet.dtos;

namespace BankingAppDotNet.core;

public class ProgramController
{
    public static UserDto loggedInUser;
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
            return false; //make welcomeScreenPath return userDto? If empty return false?
        }

        if (pl.doLoggedInPath() == false)
        {
            return false;
        } 
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