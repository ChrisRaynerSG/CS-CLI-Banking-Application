﻿using BankingAppDotNet.core;
using BankingAppDotNet.database_management;
using BankingAppDotNet.dtos;
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
        ui = new ConsoleScreen();
    }

    public string Login()
    {
        databaseConnection.OpenConnection();
        ui.PrintDisplay("Please enter your credentials");
        Console.Write("Email: ");
        email = Console.ReadLine();
        Console.Write("Password: ");
        password = Console.ReadLine();
        
        while (!ValidateCredentials())
        {
            ui.PrintDisplay("Invalid credentials");
            Console.Write("Try again? (Y/N) ");
            string selection = Console.ReadKey().KeyChar.ToString().ToLower();
            while (selection.ToLower() != "y" && selection.ToLower() != "n")
            {
                ui.PrintDisplay("Invalid input");
                Console.Write("Try again? (Y/N) ");
                selection = Console.ReadKey().KeyChar.ToString().ToLower();
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
                databaseConnection.CloseConnection();
                return "return";
            }
        }
        databaseConnection.CloseConnection();
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

                    DateTime date = reader.GetDateTime("date_of_birth");
                    string dateString = date.ToString("yyyy-MM-dd");
                    
                    ProgramController.loggedInUser = new UserDto(reader.GetInt32("user_id"),reader.GetString("first_name"),
                        reader.GetString("last_name"), 
                        reader.GetString("email"),
                        reader.GetString("password"),
                        dateString);
                    
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