using BankingAppDotNet.database_management;
using BankingAppDotNet.dtos;
using BankingAppDotNet.user_interface;
using BankingAppDotNet.validation;
using MySql.Data.MySqlClient;

namespace BankingAppDotNet.services;

public class RegisterService
{
    private ConsoleScreen ui;
    private UserDto user;
    private DatabaseConnection db;
    
    public RegisterService()
    {
        ui = new ConsoleScreen();
        user = new UserDto();
        db = new DatabaseConnection();
        db.OpenConnection();
    }

    public string Register()
    {
        string registerOutcome = string.Empty;
     
        //first name form
        
        RegistrationPrint();
        Console.Write("Enter first name: ");
        string firstName = Console.ReadLine();
        
        while (!UserValidation.ValidateName(firstName))
        {
            RegistrationPrintInvalid();
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
        }
        user.FirstName = UserValidation.formatName(firstName);
        
        //lastName form
        
        RegistrationPrint();
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();

        while (!UserValidation.ValidateName(lastName))
        {
            RegistrationPrintInvalid();
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();
        }
        
        user.LastName = UserValidation.formatName(lastName);
        
        //email form
        RegistrationPrint();
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        
        while (!UserValidation.ValidateEmail(email))
        {
            RegistrationPrintInvalidEmail();
            Console.Write("Enter email: ");
            email = Console.ReadLine();
            while (IsEmailTaken(email))
            {
                RegistrationPrintEmailTaken(email);
                Console.Write("Selection: ");
                string keypress = Console.ReadKey().KeyChar.ToString();
                while (keypress.ToLower() != "l" && keypress.ToLower() != "c")
                {
                    RegistrationPrintEmailTaken(email);
                    Console.Write("Selection: ");
                    keypress = Console.ReadKey().KeyChar.ToString();
                }
                if (keypress.ToLower() == "l")
                {
                    LoginService login = new LoginService();
                    if (login.Login() == "success")
                    {
                        registerOutcome = "success";
                    }
                }
                else if (keypress.ToLower() == "c")
                {
                 RegistrationPrint();
                 Console.Write("Enter email: ");
                 email = Console.ReadLine();
                }
            }
        }
        
        user.Email = UserValidation.formatEmail(email);
        
        //password form
        
        RegistrationPrintPassword();
        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        while (!UserValidation.ValidatePassword(password))
        {
            RegistrationPrintPasswordInvalid();
            Console.Write("Enter password: ");
            password = Console.ReadLine();
        }
        user.Password = password;
        
        //DoB form
        
        RegistrationPrintDob();
        Console.Write("Enter Date of birth: ");
        string dateOfBirth = Console.ReadLine();
        while (!UserValidation.ValidateDateOfBirth(dateOfBirth))
        {
            RegistrationPrintDobInvalid();
            Console.Write("Enter Date of birth: ");
            dateOfBirth = Console.ReadLine();
        }
        string format = "yyyy-MM-dd";
        DateOnly dateOfBirthDate = DateOnly.ParseExact(dateOfBirth, format);
        user.BirthDate = dateOfBirthDate;
        
        ui.PrintDisplay("Please make sure the following details are correct", $"First name: {user.FirstName}", $"Last name: {user.LastName}", $"Email: {user.Email}", $"Password: {user.Password}", $"Date of birth: {user.BirthDate.ToString()}");
        Console.ReadLine();
        
        return registerOutcome;
    }

    private void RegistrationPrintPassword()
    {
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.","Password must contain at least one upper case letter, one lower case letter,", "one number and be at least 8 characters.");
    }
    
    private void RegistrationPrintPasswordInvalid()
    {
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.","Invalid Password!","Password must contain at least one upper case letter, one lower case letter,", "one number and be at least 8 characters.","Invalid password!");
    }

    private void RegistrationPrintDob()
    {
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.","Date of birth must be in format YYYY-MM-DD.");
    }

    private void RegistrationPrintDobInvalid()
    {
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.","Invalid Date of Birth!","Date of birth must be in format YYYY-MM-DD,", "the date must be a valid date,", "and you must be over 18 to register");
    }

    private void RegistrationPrint()
    {
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.");
    }

    private void RegistrationPrintInvalid()
    {
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.","Invalid input, names cannot contain numbers or special characters");
    }
    
    private void RegistrationPrintInvalidEmail()
    {
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.","Invalid input, please enter a valid email address");
    }
    
    private void RegistrationPrintEmailTaken(string email)
    {
        ui.PrintDisplay("Account registration", "Please follow the instructions below to register your account.","",$"Email {email} is already taken, do you want to log in?", "Login (L)", "Continue (C)");
    }

    private bool IsEmailTaken(string email)
    {
        string query = $"SELECT * FROM users WHERE email = '{email}'";
        MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            } 
            reader.Close();
            return false;
        }
    }

    //todo firstName, lastName, email, password, DoB
    
}