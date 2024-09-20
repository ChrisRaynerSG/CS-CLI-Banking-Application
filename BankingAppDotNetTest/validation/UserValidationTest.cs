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
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestValidateUserNameReturnsTrueWhenNameStartsWithSpace()
    {
        bool expected = true;
        bool actual = UserValidation.ValidateName("  Bobby");
        Assert.That(actual, Is.EqualTo(expected));
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
        bool actual = UserValidation.ValidateEmail("bobby.theman@gmail.com");
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
}