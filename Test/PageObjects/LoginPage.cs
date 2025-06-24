using Core.Element;

using OpenQA.Selenium;

namespace Test.PageObjects
{
    public class LoginPage 
    {
        #region elements
        private readonly WebObject _usernameTxt = new WebObject(By.Id("username"), "Username Text Box");
        private readonly WebObject _usernameEmptyWarningLbl 
            = new WebObject(By.XPath("//input[@id='username']/../div[contains(@class,'message-error')]/p"), "Username Warning Message");
        private readonly WebObject _passwordTxt = new WebObject(By.Id("password"), "Password Text Box");
        private readonly WebObject _passwordEmptyWarningLbl 
            = new WebObject(By.XPath("//input[@id='password']/../div[contains(@class,'message-error')]/p"), "Password Warning Message");
        private readonly WebObject _loginBtn = new WebObject(By.XPath("//input[@value='Login']"), "Login button");
        private readonly WebObject _loginWarningMsg = new WebObject(By.XPath("//form//div[contains(@class,'alert')]"), "Login Warning message");
        #endregion

        #region msg
        public static readonly string WRONG_USERNAME_OR_PASSWORD_MSG = "The Username or Password you entered is incorrect";
        #endregion
        public void EnterUsername(string username){
            _usernameTxt.EnterText(username);
        }
        public void EnterPassword(string password){
            _passwordTxt.EnterText(password);
        }
        public void ClickLogin(){
            _loginBtn.ClickOnElement();
        }
        public void Login(string username, string password){
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }
        public string GetLoginWarningMsg(){
            return _loginWarningMsg.WaitForElementToBeVisible().Text;
        }
        public string GetEmptyUsernameWarningMsg(){
            return _usernameEmptyWarningLbl.WaitForElementToBeVisible().Text;
        }
        public string GetEmptyPasswordWarningMsg(){
            return _passwordEmptyWarningLbl.WaitForElementToBeVisible().Text;
        }
      
    }
}