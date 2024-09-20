using System.Text.RegularExpressions;
using BankingAppDotNet.services;

namespace BankingAppDotNet.validation;

public static class UserValidation
{
    public static bool ValidateName(string name)
    {
        return Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z-]*$");
    }

    public static bool ValidateEmail(String email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public static bool ValidatePassword(String password)
    {
        return false;
    }

    public static bool ValidateDateOfBirth(String dateOfBirth)
    {
        return false;
    }

    public static string formatName(String name)
    {
        return name.Trim();
    }
}