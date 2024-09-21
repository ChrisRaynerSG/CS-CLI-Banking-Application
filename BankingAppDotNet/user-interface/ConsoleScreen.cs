namespace BankingAppDotNet.user_interface;

public class ConsoleScreen
{
    private String consoleDisplay;
    
    public ConsoleScreen()
    {
        
    }
    
    public void PrintDisplay(string message1)
    {
        Console.Clear();
        Console.WriteLine(UserInterfaceComponents.TopLine);
        Console.WriteLine(UserInterfaceComponents.AppName);
        for (int i = 0; i < 9; i++)
        {
            if (i == 5)
            {
                Console.WriteLine(
                    UserInterfaceComponents.GetMessageString(message1));
            }
            else
            {
                Console.WriteLine(UserInterfaceComponents.MiddleLine);
            }
        }
        Console.WriteLine(UserInterfaceComponents.MiddleLine);
        Console.WriteLine(UserInterfaceComponents.BottomLine);
    }
    
    public void PrintDisplay(string message1, string message2)
    {
        Console.Clear();
        Console.WriteLine(UserInterfaceComponents.TopLine);
        Console.WriteLine(UserInterfaceComponents.AppName);
        for (int i = 0; i < 9; i++)
        {
            if (i == 5)
            {
                Console.WriteLine(
                    UserInterfaceComponents.GetMessageString(message1));
            }
            else if (i == 6)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message2));
            }
            else
            {
                Console.WriteLine(UserInterfaceComponents.MiddleLine);
            }
        }
        Console.WriteLine(UserInterfaceComponents.MiddleLine);
        Console.WriteLine(UserInterfaceComponents.BottomLine);
    }
    public void PrintDisplay(string message1, string message2, string message3)
    {
        Console.Clear();
        Console.WriteLine(UserInterfaceComponents.TopLine);
        Console.WriteLine(UserInterfaceComponents.AppName);
        for (int i = 0; i < 9; i++)
        {
            if (i == 4)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message1));
            }
            else if (i == 5)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message2));
            }
            else if (i == 6)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message3));
            }
            else
            {
                Console.WriteLine(UserInterfaceComponents.MiddleLine);
            }
        }
        Console.WriteLine(UserInterfaceComponents.MiddleLine);
        Console.WriteLine(UserInterfaceComponents.BottomLine);
    }
    
    

    public void PrintDisplay(string message1, string message2, string message3, string message4)
    {
        Console.Clear();
        Console.WriteLine(UserInterfaceComponents.TopLine);
        Console.WriteLine(UserInterfaceComponents.AppName);
        for (int i = 0; i < 9; i++)
        {
            if (i == 2)
            {
                Console.WriteLine(
                    UserInterfaceComponents.GetMessageString(message1));
            }
            else if (i == 4)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message2));
            }
            else if (i == 5)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message3));
            }
            else if (i == 6)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message4));
            }
            else
            {
                Console.WriteLine(UserInterfaceComponents.MiddleLine);
            }
        }
        Console.WriteLine(UserInterfaceComponents.MiddleLine);
        Console.WriteLine(UserInterfaceComponents.BottomLine);
    }
    public void PrintDisplay(string message1, string message2, string message3, string message4, string message5, string message6)
    {
        Console.Clear();
        Console.WriteLine(UserInterfaceComponents.TopLine);
        Console.WriteLine(UserInterfaceComponents.AppName);
        for (int i = 0; i < 9; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(
                    UserInterfaceComponents.GetMessageString(message1));
            }
            else if (i == 3)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message2));
            }
            else if (i == 4)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message3));
            }
            else if (i == 5)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message4));
            }
            else if (i == 6)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message5));
            }
            else if (i == 7)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message6));
            }
            else
            {
                Console.WriteLine(UserInterfaceComponents.MiddleLine);
            }
        }
        Console.WriteLine(UserInterfaceComponents.MiddleLine);
        Console.WriteLine(UserInterfaceComponents.BottomLine);
    }
    public void PrintDisplay(string message1, string message2, string message3, string message4, string message5, string message6, string message7)
    {
        Console.Clear();
        Console.WriteLine(UserInterfaceComponents.TopLine);
        Console.WriteLine(UserInterfaceComponents.AppName);
        for (int i = 0; i < 9; i++)
        {
            if (i == 1)
            {
                Console.WriteLine(
                    UserInterfaceComponents.GetMessageString(message1));
            }
            else if (i == 3)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message2));
            }
            else if (i == 4)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message3));
            }
            else if (i == 5)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message4));
            }
            else if (i == 6)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message5));
            }
            else if (i == 7)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message6));
            }
            else if (i == 8)
            {
                Console.WriteLine(UserInterfaceComponents.GetMessageString(message7));
            }
            else
            {
                Console.WriteLine(UserInterfaceComponents.MiddleLine);
            }
        }
        Console.WriteLine(UserInterfaceComponents.MiddleLine);
        Console.WriteLine(UserInterfaceComponents.BottomLine);
    }
}