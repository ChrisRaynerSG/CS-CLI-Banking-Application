namespace BankingAppDotNet.database_management;
using MySql.Data.MySqlClient;

public class DatabaseConnection
{
    private MySqlConnection connection { get; set; }
    private string ConnectionString;

    
    public DatabaseConnection()
    {
        ConnectionString = DatabaseConfigSetup.GetConnectionString();
        connection = new MySqlConnection(ConnectionString);
        
    }
    
    public void OpenConnection()
    {
        try
        {
            connection.Open();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void CloseConnection()
    {
        try
        {
            connection.Close();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public MySqlConnection GetConnection()
    {
        return connection;
    }
}