using FluentAssertions;

using Reqnroll;

using Test.PageObjects;

namespace Test.StepDefinitions;

[Binding]
public sealed class SearchProjectStepDefinitions
{
    private LoginPage _loginPage;
    private SearchProjectPage _searchProjectPage;
    private ScenarioContext _scenarioContext;
    public SearchProjectStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _loginPage = new LoginPage();
        _searchProjectPage = new SearchProjectPage();
    }

    [Given("user logins with username {string} and password {string}")]
    public void StepUserLoginWithUsernameAndPassword(string username, string password)
    {
        _loginPage.Login(username, password);
    }

    [Given("user go to Search Project page")]
    public void StepUserGoToSearchProjectPage()
    {
        _searchProjectPage.NavigateToPage();
    }

    [Given("user select {string} in Location field")]
    public void StepUserSelectInLocationField(string location)
    {
        if (!string.IsNullOrWhiteSpace(location))
        {
            _searchProjectPage.SelectLocation(location);
        }
    }

    [Given("user enter {string} into Project Name field")]
    public void StepUserEnterIntoProjectNameField(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            _searchProjectPage.EnterName(name);
        }

    }

    [Given("user select {string} in Project Type field")]
    public void StepUserSelectInProjectTypeField(string type)
    {
        if (!string.IsNullOrWhiteSpace(type))
        {
            _searchProjectPage.SelectType(type);
        }

    }

    [Given("user click Search button")]
    public void StepUserClickSearchButton()
    {
        _searchProjectPage.ClickSearchButton();
    }

    [Then("all the searched Projects match the entered criterias")]
    public void ThenAllTheSearchedProjectsMatchTheEnteredCriterias()
    {
        _searchProjectPage.HasSearchResult().Should().BeTrue();
    }

    // This step definition uses Cucumber Expressions. See https://github.com/gasparnagy/CucumberExpressions.SpecFlow
    [Then("No Result warning message show")]
    public void ThenNoResultWarningMessageShow()
    {
        _searchProjectPage.IsSearchEmpty().Should().BeTrue();
    }
    

  
}