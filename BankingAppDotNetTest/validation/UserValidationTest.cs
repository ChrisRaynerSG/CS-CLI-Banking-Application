using BankingAppDotNet.validation;
namespace BankingAppDotNetTest.validation;

public class UserValidationTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestValidateUserNameReturnsTrueWhenNameIsValid()
    {
        bool expected = true;
        bool actual = UserValidation.ValidateName("Bobby");
        bool actual2 = UserValidation.ValidateName("Bobby-Brown");
        Assert.That(actual, Is.EqualTo(expected));
        Assert.That(actual2, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestValidateUserNameReturnsFalseWhenNameIsEmpty()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateName("");
        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void TestValidateUserNameReturnsFalseWhenAllBlankSpace()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateName("      ");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidateUserNameReturnsFalseWhenNumbersInName()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateName("B0bby");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidateUserNameReturnsFalseWhenSpecialCharactersPresent()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateName("Bobb^i");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidateEmailReturnsTrueWhenEmailIsValid()
    {
        bool expected = true;
        bool actual = UserValidation.ValidateEmail("bobby.theman@gmail.co.uk");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidateEmailReturnsFalseWhenEmailIsEmpty()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateEmail("");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidateEmailReturnsFalseWhenAllBlankSpace()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateEmail("  ");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidateEmailReturnsFalseWhenInvalidEmail()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateEmail("bobgmail.com");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidatePasswordReturnsTrueWhenPasswordIsValid()
    {
        bool expected = true;
        bool actual = UserValidation.ValidatePassword("Password1");
        bool actual2 = UserValidation.ValidatePassword("Pa55word2");
        Assert.That(actual, Is.EqualTo(expected));
        Assert.That(actual2, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidatePasswordReturnsFalseWhenPasswordIsLessThan8()
    {
        bool expected = false;
        bool actual = UserValidation.ValidatePassword("Passwo1");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidatePasswordReturnsFalseWhenPasswordContainsNoCapitalLetter()
    {
        bool expected = false;
        bool actual = UserValidation.ValidatePassword("password1");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidatePasswordReturnsFalseWhenNoNumbersPresent()
    {
        bool expected = false;
        bool actual = UserValidation.ValidatePassword("Passwords");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void testValidateDateOfBirthReturnsTrueWhenDateOfBirthIsValid()
    {
        bool expected = true;
        bool actual = UserValidation.ValidateDateOfBirth("1992-02-29");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void testValidateDateOfBirthReturnsFalseWhenDateOfBirthMakesAgeYoungerThan18()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateDateOfBirth("2020-01-01");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void testValidateDateOfBirthReturnsFalseWhenDateOfBirthIsBefore1920()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateDateOfBirth("1918-01-01");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void testValidateDateOfBirthReturnsFalseWhenDateOfBirthIsNotValidDate()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateDateOfBirth("1992-02-30");
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void testValidateDateOfBirthReturnsFalseWhenDateOfBirthIsNotInValidFormat()
    {
        bool expected = false;
        bool actual = UserValidation.ValidateDateOfBirth("27-12-1992");
        Assert.That(actual, Is.EqualTo(expected));
    }
}