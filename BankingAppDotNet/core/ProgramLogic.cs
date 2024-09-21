namespace BankingAppDotNet.core;

public class ProgramLogic
{
    private readonly DatabaseSetupLogic databaseSetupLogic;
    private readonly WelcomeScreenLogic welcomeScreenLogic;
    
    public ProgramLogic()
    {
        databaseSetupLogic = new DatabaseSetupLogic();
        welcomeScreenLogic = new WelcomeScreenLogic();
    }

    public bool doDatabaseSetupPath()
    {
       return databaseSetupLogic.SetupDatabase();
    }

    public bool doWelcomeScreenPath()
    {
        return welcomeScreenLogic.doWelcomeScreenPath();
    }
}