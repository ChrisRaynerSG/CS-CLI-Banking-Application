namespace BankingAppDotNet.dtos;

public class UserDto
{
    public int Id {get; set;}
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string BirthDate { get; set; }

    public UserDto(int id,string firstName, string lastName, string email, string password, string birthDate)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        BirthDate = birthDate;
    }

    public UserDto()
    {
        
    }
}