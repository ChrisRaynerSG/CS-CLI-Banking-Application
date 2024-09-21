using BankingAppDotNet.database_management;
using BankingAppDotNet.user_interface;

namespace BankingAppDotNet.core;

public class DatabaseSetupLogic : ConsoleScreen
{
    public bool SetupDatabase()
    {
        int counter = 0;
        while(!DatabaseConfigSetup.VerifyConfigJson())
        {
            if (counter != 0)
            {
                
                PrintDisplay("ERR: invalid credentials!", "Try again? (Y/N) ");
                string userInput = Console.ReadKey().KeyChar.ToString();
                while (userInput.ToLower() != "y" && userInput.ToLower() != "n")
                {
                    PrintDisplay("ERR: invalid credentials!", "Try again? (Y/N) ");
                    userInput = Console.ReadKey().KeyChar.ToString();
                }

                if (userInput.ToLower() == "n")
                {
                    PrintDisplay("Shutting down.");
                    Thread.Sleep(500);
                    PrintDisplay("Shutting down..");
                    Thread.Sleep(500);
                    PrintDisplay("Shutting down...");
                    Thread.Sleep(500);
                    PrintDisplay("Shutting down....");
                    Thread.Sleep(500);
                    return false;
                }
            }
            
            counter++;
            
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

        return true;
    }
    
    private void PrintDatabaseSetup(string message)
    {
        PrintDisplay("It looks like you are performing first time setup.", "Please follow the instructions below.", message);
    }
    
}