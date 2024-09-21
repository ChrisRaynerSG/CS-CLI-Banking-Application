using BankingAppDotNet.database_management;
using BankingAppDotNet.dtos;
using MySql.Data.MySqlClient;

namespace BankingAppDotNet.services;

public class AccountService
{
    private DatabaseConnection databaseConnection;
    
    public AccountService()
    {
        databaseConnection = new DatabaseConnection();
    }

    public bool doesUserHaveAccounts(UserDto user)
    {
        string query = $"SELECT * FROM accounts WHERE user_id = {user.Id}";
        databaseConnection.OpenConnection();
        MySqlCommand command = new MySqlCommand(query, databaseConnection.GetConnection());
        bool doesUserHaveAccount = command.ExecuteReader().Read();
        databaseConnection.CloseConnection();
        return doesUserHaveAccount;
    }

    public void getAllAccounts(UserDto user)
    {
        databaseConnection.OpenConnection();
        
        
    }
}