using Core.Element;

using OpenQA.Selenium;

namespace Test.PageObjects
{
    //In future may add Search Employee page
    public class BaseUserPage
    {
        private WebObject _searchTypeDdl = new WebObject(By.Id("type"));
        private WebObject SearchTypeOpt(string searchType)
            => new WebObject(By.XPath($"//select[@id='type']//option[@value='{searchType}']"), "Search Type Option");
        private WebObject _headerProjectItem =
        new WebObject(By.XPath("//div[@id='navbar']//li[contains(@class, 'dropdown')]//a[contains(text(),'Projects')]"), "Header Project Item");
        private WebObject _headerCreateProjectBtn =
            new WebObject(By.XPath("//div[@id='navbar']//li[contains(@class, 'dropdown')]//a[contains(text(),'Create Project')]"), "Create Project Button");
        public void OpenCreateProjectPopup()
        {
            _headerProjectItem.ClickOnElement();
            _headerCreateProjectBtn.ClickOnElement();
        }
        public void SwitchToSearchType(string searchType)
        {
            _searchTypeDdl.ClickOnElement();
            SearchTypeOpt(searchType).ClickOnElement();
            _searchTypeDdl.ClickOnElement();
        }
        public void WaitUntilPageLoad()
        {
            _searchTypeDdl.WaitForElementToBeClickable();
        }
    }
}