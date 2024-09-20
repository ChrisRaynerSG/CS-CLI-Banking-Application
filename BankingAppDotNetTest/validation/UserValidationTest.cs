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
    
    
}