namespace BankingAppDotNet.dtos;

public class AccountDto
{
    public int accountId { get; set; }
    public string sortCode { get; set; }
    public string accountNumber { get; set; }
    public string accountType { get; set; }
    public decimal balance { get; set; }


    public AccountDto() {}

    public AccountDto(int accountId, string sortCode, string accountNumber, string accountType, decimal balance)
    {
        this.accountId = accountId;
        this.sortCode = sortCode;
        this.accountNumber = accountNumber;
        this.accountType = accountType;
        this.balance = balance;
    }
}