using System.Globalization;
using BankingAppDotNet.dtos;
using BankingAppDotNet.user_interface;
using Org.BouncyCastle.Pqc.Crypto.Utilities;

namespace BankingAppDotNet.services;

public class RegisterService
{
    private ConsoleScreen ui;
    private UserDto user;
    
    public RegisterService()
    {
        ui = new ConsoleScreen();
        user = new UserDto();
    }

    public string Register()
    {
        string registerOutcome = string.Empty;
        RegistrationPrint();
        Console.Write("Enter first name: ");
        user.FirstName = Console.ReadLine();
        RegistrationPrint();
        Console.Write("Enter last name: ");
        user.LastName = Console.ReadLine();
        RegistrationPrint();
        Console.Write("Enter email: ");
        user.Email = Console.ReadLine();
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.","Password must contain at least one upper case letter, one lower case letter,", "one number and be at least 8 characters.");
        Console.Write("Enter password: ");
        user.Password = Console.ReadLine();
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.","Date of birth must be in format YYYY-MM-DD.");
        Console.Write("Enter Date of birth: ");
        string dateOfBirth = Console.ReadLine();
        string format = "yyyy-MM-dd";
        DateOnly dateOfBirthDate = DateOnly.ParseExact(dateOfBirth, format , CultureInfo.InvariantCulture);
        user.BirthDate = dateOfBirthDate;
        ui.PrintDisplay("Please make sure the following details are correct", $"First name: {user.FirstName}", $"Last name: {user.LastName}", $"Email: {user.Email}", $"Password: {user.Password}", $"Date of birth: {user.BirthDate.ToString()}");
        Console.ReadLine();
        return registerOutcome;
    }

    private void RegistrationPrint()
    {
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.");
    }

    //todo firstName, lastName, email, password, DoB
    
}