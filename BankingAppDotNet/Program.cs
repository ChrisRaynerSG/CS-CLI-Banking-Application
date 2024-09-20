using BankingAppDotNet.core;
using BankingAppDotNet.user_interface;

namespace BankingAppDotNet;

class Program
{
    public static bool IsRunning = true;
    
    public static void Main(string[] args)
    {
        while(IsRunning) 
        {
            ProgramController programController = new ProgramController();
            programController.RunApplication();
        }
    }
}