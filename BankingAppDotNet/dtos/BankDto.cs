using BankingAppDotNet.core;

namespace BankingAppDotNet.dtos;

public class BankDto
{
    public int bankId { get; set; }
    public string bankName { get; set; }
    public string bankCode { get; set; }
    public string address1 { get; set; }
    public string address2 { get; set; }
    public string address3 { get; set; }
    public string city { get; set; }
    
    public BankDto(){}

    public BankDto(int bankId, string bankName, string bankCode, string address1, string address2, string address3,
        string city)
    {
        this.bankId = bankId;
        this.bankName = bankName;
        this.bankCode = bankCode;
        this.address1 = address1;
        this.address2 = address2;
        this.address3 = address3;
        this.city = city;
    }
}