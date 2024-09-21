using BankingAppDotNet.dtos;

namespace BankingAppDotNet.core;

public class ProgramLogic
{
    private readonly DatabaseSetupLogic databaseSetupLogic;
    private readonly WelcomeScreenLogic welcomeScreenLogic;
    private readonly LoggedInScreenLogic loggedInScreenLogic;
    
    public ProgramLogic()
    {
        databaseSetupLogic = new DatabaseSetupLogic();
        welcomeScreenLogic = new WelcomeScreenLogic();
        loggedInScreenLogic = new LoggedInScreenLogic();
    }

    public bool doDatabaseSetupPath()
    {
       return databaseSetupLogic.SetupDatabase();
    }

    public bool doWelcomeScreenPath()
    {
        //todo refactor this into login and register?
        return welcomeScreenLogic.doWelcomeScreenPath();
    }

    public bool doLoggedInPath(UserDto user)
    {
        return loggedInScreenLogic.doLoggedInScreenPath(user);
    }
}