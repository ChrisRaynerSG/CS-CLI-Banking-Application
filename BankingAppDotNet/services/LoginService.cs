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
            ui.PrintDisplay("Invalid credentials");
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
                ui.PrintDisplay("Please enter your credentials");
                Console.Write("Email: ");
                email = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
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
                return false;
            }
            while (reader.Read())
            {
                if (reader.GetString("password") == password)
                {
                    ui.PrintDisplay("Login successful!", "Welcome " + reader.GetString("first_name") + " " + reader.GetString("last_name") + "!");
                    Thread.Sleep(3000);
                    return true;
                }
                return false;
            }
        }
        return false;
    }
    
}