using Core.Utils;

using FluentAssertions;

using Reqnroll;

using Test.Const;
using Test.PageObjects;

namespace Test.StepDefinitions;

[Binding]
public sealed class LoginStepDefinitions
{
    private LoginPage _loginPage = new LoginPage();
    private BaseUserPage _baseSearchPage = new BaseUserPage();
    [Given("user go to login page")]
    public void GivenUserGoToLoginPage()
    {
    }


    [When("user enter {string} into Username field")]
    public void StepUserEnterIntoUsernameField(string username)
    {
        _loginPage.EnterUsername(username);
    }

    [When("user enter {string} into password field")]
    public void WhenUserEnterIntoPasswordField(string password)
    {
        _loginPage.EnterPassword(password);
    }

    [When("user click Login button")]
    public void WhenUserClickLoginButton()
    {
        _loginPage.ClickLogin();
    }
    [Then("user go to Search Employee page")]
    public void ThenUserGoToSearchEmployeePage()
    {
        _baseSearchPage.WaitUntilPageLoad();
        string url = DriverUtils.GetUrl();
        url.Should().Be(ConfigurationUtils.GetConfigurationByKey("TestUrl") + PathConst.SEARCH_RELATIVE_URL);

    }

    [Then("user see empty username password warning message")]
    public void ThenUserSeeEmptyUsernamePasswordWarningMessage()
    {
        _loginPage.GetEmptyUsernameWarningMsg().Should().Be(MessageConst.REQUIRED_FIELD_WARNING_MSG);
        _loginPage.GetEmptyPasswordWarningMsg().Should().Be(MessageConst.REQUIRED_FIELD_WARNING_MSG);

    }

    [Then("user see empty password warning message")]
    public void ThenUserSeeEmptyPasswordWarningMessage()
    {
        _loginPage.GetEmptyPasswordWarningMsg().Should().Be(MessageConst.REQUIRED_FIELD_WARNING_MSG);
    }

    [Then("user see empty username warning message")]
    public void ThenUserSeeEmptyUsernameWarningMessage()
    {
        _loginPage.GetEmptyUsernameWarningMsg().Should().Be(MessageConst.REQUIRED_FIELD_WARNING_MSG);
    }

    [Then("user see wrong username password warning message")]
    public void ThenUserSeeWrongUsernamePasswordWarningMessage()
    {
        _loginPage.GetLoginWarningMsg().Should().Be(MessageConst.WRONG_USERNAME_OR_PASSWORD_MSG);
    }
}
