using System;

using Core.Element;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Test.PageObjects
{
    public class SearchProjectPage: BaseUserPage
    {
        #region Elements
        private WebObject _searchBtn = new WebObject(By.XPath("//form[@name='myForm']//span[@ui-view='project']//button[contains(@class, 'search')]"), "Search Project Button");
        private WebObject _warningMsg = new WebObject(By.XPath("//div[@ui-view='projectsresult']//label/strong"),"Warning message");
        private WebObject _numOfSearchedProjectLbl = new WebObject(By.XPath("//label[contains(text(),'Total Results: ')]"), "Search Result Number Lable");
        private WebObject _nameTxt = new WebObject(By.XPath("//label[@class='search-label'][text()= 'Project Name']/../input"), "Name Text Box");
        private WebObject _locationDdl = new WebObject(By.Id("ddl-location"), "Location Dropdown List");
        private WebObject _typeDdl = new WebObject(By.Id("ddl-projecttype"), "Type Dropdown List");

        #endregion
        #region Action
        public void NavigateToPage()
        {
            SwitchToSearchType("Project");
        }
        public void EnterName(string name)
        {
            _nameTxt.EnterText(name);
        }
        public void SelectLocation(string location)
        {
            // _locationDdl.ClickOnElement();
            // LocationOpt(location).ClickOnElement();
            // _locationDdl.ClickOnElement();
            SelectElement selectElement = new SelectElement(_locationDdl.WaitForElementToBeClickable());
            selectElement.SelectByText(location);
        }
        public void SelectType(string type)
        {
            SelectElement selectElement = new SelectElement(_typeDdl.WaitForElementToBeClickable());
            selectElement.SelectByText(type);
        }
        public void ClickSearchButton(){
            _searchBtn.ClickOnElement();
        }
        public void SearchProject(string name="", string location="", string type=""){
            if(!String.IsNullOrWhiteSpace(name)){
                EnterName(name);
            }
            if(!String.IsNullOrWhiteSpace(location)){
                SelectLocation(location);
            }
            if(!String.IsNullOrEmpty(type)){
                SelectType(type);
            }
            _searchBtn.ClickOnElement();
        }
        public bool HasSearchResult(){
            return _numOfSearchedProjectLbl.IsElementDisplayed();
        }
        public bool IsSearchEmpty(){
            return _warningMsg.IsElementDisplayed();
        }
        public string GetEmptySearchResultWarningMsg(){
            return _warningMsg.WaitForElementToBeVisible().Text;
        }
        public int SearchResultsCount(){
            string countResultsLblValue = _numOfSearchedProjectLbl.WaitForElementToBeVisible().Text;
            int count = Int32.Parse(countResultsLblValue.Split("Total Results: ")[1]);
            return count;
        }
        #endregion 
    }
}