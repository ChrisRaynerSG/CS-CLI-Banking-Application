namespace BankingAppDotNet.dtos;

public class UserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateOnly BirthDate { get; set; }

    public UserDto(string firstName, string lastName, string email, string password, DateOnly birthDate)
    {
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