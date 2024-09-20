using BankingAppDotNet.database_management;
using MySql.Data.MySqlClient;


namespace BankingAppDotNet.services;

public class LoginService
{
    private string email;
    private string password;
    private DatabaseConnection databaseConnection;
    
    public LoginService()
    {
        databaseConnection = new DatabaseConnection();
        databaseConnection.OpenConnection();
    }

    public void Login(String email, String password)
    {
        string query = "SELECT * FROM users;";
        MySqlCommand cmd = new MySqlCommand(query, databaseConnection.GetConnection());
        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"{reader["first_name"]}, {reader["last_name"]}");
            }
        }
        
    }
    
    
}