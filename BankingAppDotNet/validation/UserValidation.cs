using System.Text.RegularExpressions;
using BankingAppDotNet.services;

namespace BankingAppDotNet.validation;

public static class UserValidation
{
    public static bool ValidateName(string name)
    {
        return Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z-]*$");
    }

    public static bool ValidateEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public static bool ValidatePassword(string password)
    {
        return Regex.IsMatch(password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}$");
    }

    public static bool ValidateDateOfBirth(string dateOfBirth)
    {
        try
        {
            DateOnly date = DateOnly.ParseExact(dateOfBirth, format: "yyyy-MM-dd");
            if (date.Year < 1920 || DateOnly.FromDateTime(DateTime.Now).Year - date.Year < 18) //must be over 18 to open an account
            {
                return false;
            }
            return true;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return false;
    }

    public static string formatName(string name)
    {
        return name.Trim();
    }

    public static string formatEmail(string email)
    {
        email = email.ToLower();
        return email.Trim();
        
    }
}