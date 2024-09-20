using BankingAppDotNet.user_interface;

namespace BankingAppDotNet;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(UserInterfaceComponents.TopLine + "\n" + UserInterfaceComponents.AppName);
        for (int i = 0; i < 10; i++)
        {
            if (i == 6)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString("Hello world! Again!"));
            }
            else
            {
                Console.WriteLine(UserInterfaceComponents.MiddleLine);
            }
        }
        Console.WriteLine(UserInterfaceComponents.BottomLine);
        
        
        
    }
}