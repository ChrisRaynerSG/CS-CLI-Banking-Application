using Microsoft.Extensions.Configuration;
using System;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace BankingAppDotNet.database_management;

public static class DatabaseConfigSetup
{
    public static void WriteConfigJson(string serverLocation, string port, string schema, string username, string password)
    {
        var configFile = "databasesettings.json";
        var configData = new Dictionary<string, object>
        {
            { "DatabaseServer", serverLocation },
            { "DatabasePort", port },
            { "DatabaseSchema", schema },
            { "Username", username },
            { "Password", password }
        };
        
        string json = JsonConvert.SerializeObject(configData, Formatting.Indented);
        File.WriteAllText(configFile, json);
    }

    public static bool VerifyConfigJson()
    {
        try
        {
            DatabaseConnection dbc = new DatabaseConnection();
            dbc.OpenConnection();
            string query = "SELECT * FROM banks";
            MySqlCommand cmd = new MySqlCommand(query, dbc.GetConnection());
            cmd.ExecuteReader();
            dbc.CloseConnection();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public static string GetConnectionString()
    {
        var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("databasesettings.json", optional:false).Build();
        
        string server = configuration["DatabaseServer"];
        string port = configuration["DatabasePort"];
        string schema = configuration["DatabaseSchema"];
        string user = configuration["Username"];
        string password = configuration["Password"];
        return $"Server={server};Port={port};Database={schema};User ID={user};Password={password}";
    }
}