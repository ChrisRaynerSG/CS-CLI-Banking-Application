namespace BankingAppDotNet.user_interface;

public static class UserInterfaceComponents
{
    
    public const string TopLine =    "----------------------------------------------------------------------------------";
    public const string AppName =    "|                            CRSG Banking Application                            |";
    public const string BottomLine = "|________________________________________________________________________________|";
    public const string MiddleLine = "|                                                                                |";
    
    public static string GetMessageString(string message)
    {
        int totalWidth = 80;
        int padding = (totalWidth - message.Length) / 2;
        
        return $"|{"".PadLeft(padding)}{message}{"".PadRight(totalWidth-padding - message.Length)}|";
    }

}