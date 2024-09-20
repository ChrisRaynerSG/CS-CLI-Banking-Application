using BankingAppDotNet.database_management;
using BankingAppDotNet.user_interface;
using MySql.Data.MySqlClient;


namespace BankingAppDotNet.services;

public class LoginService
{
    private string email;
    private string password;
    private DatabaseConnection databaseConnection;
    private ConsoleScreen ui;
    
    public LoginService()
    {
        databaseConnection = new DatabaseConnection();
        databaseConnection.OpenConnection();
        ui = new ConsoleScreen();
    }

    public string Login()
    {
        ui.PrintDisplay("Please enter your credentials");
        Console.Write("Email: ");
        email = Console.ReadLine();
        Console.Write("Password: ");
        password = Console.ReadLine();
        
        while (!ValidateCredentials())
        {
            Console.Write("Try again? (Y/N) ");
            string selection = Console.ReadLine();
            while (selection.ToLower() != "y" && selection.ToLower() != "n")
            {
                ui.PrintDisplay("Invalid input");
                Console.Write("Try again? (Y/N) ");
                selection = Console.ReadLine();
            }

            if (selection.ToLower() == "y")
            {
                ValidateCredentials();
            }
            else
            {
                return "return";
            }
        }

        return "success";
    }

    private bool ValidateCredentials()
    {
        string query = $"SELECT * FROM users WHERE email = '{email}'";
        MySqlCommand cmd = new MySqlCommand(query, databaseConnection.GetConnection());
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (!reader.HasRows)
            {
                ui.PrintDisplay($"{email} is not registered.","Please try again, or register an account");
                Console.Write("Enter email: ");
                email = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                return false;
            }
            while (reader.Read())
            {
                if (reader.GetString("password") == password)
                {
                    ui.PrintDisplay("Login successful!", "Welcome " + reader.GetString("first_name") + " " + reader.GetString("last_name") + "!");
                    return true;
                }
                ui.PrintDisplay("Password does not match");
                Console.Write("Enter password: ");
                password = Console.ReadLine();
                return false;
            }
        }
        return false;
    }
    
}