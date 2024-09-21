namespace BankingAppDotNet.user_interface;

public static class UserInterfaceComponents
{
    
    public const string TopLine =    "----------------------------------------------------------------------------------------------------------------------------------------------";
    public const string AppName =    "|                                                          CRSG Banking Application                                                          |";
    public const string BottomLine = "|____________________________________________________________________________________________________________________________________________|";
    public const string MiddleLine = "|                                                                                                                                            |";
    
    public static string GetMessageString(string message)
    {
        int totalWidth = 160;
        int padding = (totalWidth - message.Length) / 2;
        
        return $"|{"".PadLeft(padding)}{message}{"".PadRight(totalWidth-padding - message.Length)}|";
    }

    public static string GetBankTableRowString(string selection, string bankName, string sortCode, string address1, string address2, string address3, string city)
    {

        int totalWidth = 20;
        int selectionPadding = (totalWidth - selection.Length) / 2;
        int bankNamePadding = (totalWidth - bankName.Length) / 2;
        int sortCodePadding = (totalWidth - sortCode.Length) / 2;
        int address1Padding = (totalWidth - address1.Length) / 2;
        int address2Padding = (totalWidth - address2.Length) / 2;
        int address3Padding = (totalWidth - address3.Length) / 2;
        int cityPadding = (totalWidth - city.Length) / 2;
        
        return $"|{"".PadLeft(selectionPadding)}{selection}{"".PadRight(totalWidth-selectionPadding-selection.Length)}|{"".PadLeft(bankNamePadding)}{bankName}{"".PadRight(totalWidth-bankNamePadding-bankName.Length)}"+
               $"|{"".PadLeft(sortCodePadding)}{sortCode}{"".PadRight(totalWidth-sortCodePadding-sortCode.Length)}|{"".PadLeft(address1Padding)}{address1}{"".PadRight(totalWidth-address1Padding-address1.Length)}"+
               $"|{"".PadLeft(address2Padding)}{address2}{"".PadRight(totalWidth-address2Padding-address2.Length)}|{"".PadLeft(address3Padding)}{address3}{"".PadRight(totalWidth-address3Padding-address3.Length)}"+
               $"|{"".PadLeft(cityPadding)}{city}{"".PadRight(totalWidth-cityPadding-city.Length)}|";
        
        
        
    }

}