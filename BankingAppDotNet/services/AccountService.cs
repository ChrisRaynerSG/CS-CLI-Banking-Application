using System.Collections;
using BankingAppDotNet.core;
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

    public bool DoesUserHaveAccounts(UserDto user)
    {
        string query = $"SELECT * FROM accounts WHERE user_id = {user.Id}";
        databaseConnection.OpenConnection();
        MySqlCommand command = new MySqlCommand(query, databaseConnection.GetConnection());
        bool doesUserHaveAccount = command.ExecuteReader().Read();
        databaseConnection.CloseConnection();
        return doesUserHaveAccount;
    }

    public ArrayList GetAllAccounts(UserDto user)
    {
        var accounts = new ArrayList();
        databaseConnection.OpenConnection();
        MySqlCommand command = new MySqlCommand($"SELECT account_id, account_number,banks.bank_code, account_types.account_type_name, balance FROM accounts JOIN account_types on accounts.account_type_id = account_types.account_type_id JOIN banks ON accounts.bank_id = banks.bank_id WHERE user_id = {user.Id}", databaseConnection.GetConnection());
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                AccountDto account = new AccountDto(reader.GetInt32("account_id"), reader.GetString("bank_code"), reader.GetString("account_number"), reader.GetString("account_type_name"),reader.GetDecimal("balance"));
                accounts.Add(account);
            }
        }
        databaseConnection.CloseConnection();
        return accounts;
    }

    public ArrayList GetAllBanks()
    {
        var banks = new ArrayList();
        databaseConnection.OpenConnection();
        MySqlCommand command = new MySqlCommand("SELECT * FROM banks", databaseConnection.GetConnection());
        using (MySqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                BankDto bank = new BankDto(reader.GetInt32("bank_id"), reader.GetString("bank_name"), reader.GetString("bank_code"), reader.GetString("address1"),reader.GetString("address2"), reader.GetString("address3"), reader.GetString("city"));
                banks.Add(bank);
            }
        }
        databaseConnection.CloseConnection();
        return banks;
    }

    public void CreateNewAccount(UserDto user, int bankId, int accountTypeId)
    {
        databaseConnection.OpenConnection();
        decimal startingBalance = 0;
        string query = $"INSERT INTO accounts (user_id, bank_id, account_type_id, account_number, balance, created_at) VALUES ({ProgramController.loggedInUser.Id}, {bankId}, {accountTypeId},{GenerateAccountNumber()}, {startingBalance}, {DateTime.Now.Date})";
        MySqlCommand command = new MySqlCommand(query, databaseConnection.GetConnection());
        databaseConnection.CloseConnection();
    }

    private string GenerateAccountNumber()
    {
        int counter = 0;
        string accountNumber ="";
        while (counter == 0 || DoesAccountNumberExist(accountNumber))
        {
            accountNumber = "";
            Random random = new Random();
            for (int i = 0; i < 8; i++)
            {
                accountNumber += random.Next(0, 10).ToString();
            }
            counter++;
        }
        return accountNumber;
    }

    private bool DoesAccountNumberExist(string accountNumber)
    {
        string query = $"SELECT account_number FROM accounts WHERE account_number = '{accountNumber}'";
        MySqlCommand command = new MySqlCommand(query, databaseConnection.GetConnection());
        return command.ExecuteReader().HasRows;
    }
}