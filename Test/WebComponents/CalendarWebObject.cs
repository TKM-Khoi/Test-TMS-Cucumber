using System;
using System.Globalization;

using Core.Drivers;
using Core.Element;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using Test.Extensions;

namespace Test.Components
{
    public class CalendarObject: WebObject
    {
        public static WebDriverWait Wait() =>BrowserFactory.GetDriverWait();


        #region sub elements 
        private WebObject _monthLayoutButton = new WebObject(
            By.XPath("//th//button[contains(@id, 'datepicker') and contains(@id, 'title')]/strong"), $"Calendar Layer Button");

        private WebObject _nextBtn = new WebObject(
            By.XPath("//th//button[contains(@class, 'right')]"), "Calendar Next Button");
        private WebObject _prevBtn = new WebObject(
            By.XPath("//th//button[contains(@class, 'left')]"), "Calendar Prev Button");
        private WebObject YearBtn(int year) 
            => new WebObject(By.XPath($"//table//span[text()='{year}']"), $"Year {year} Button");
        private WebObject MonthBtn(int month) 
            => new WebObject(
                By.XPath($"//table//span[text()='{CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month)}']"), 
                $"Month {month} Button");
        
        private WebObject DateBtn(int date) 
            => new WebObject(By.XPath( $"//table//span[text()='{date.ToString("D2")}' and not(contains(@class,'muted'))]"), $"{Name} Date {date} Button");
        #endregion

        public CalendarObject(By by, string name = "") : base(by, name)
        {}
        private DateTime GetCurrentDate()
        {
            this.WaitForElementToBeClickable();
            // string dateString = _monthLayoutButton.WaitForElementToBeVisible().Text;
            string dateString = this.WaitSubElementToBeVisible(_monthLayoutButton).Text;
            return DateTime.ParseExact(dateString, "MMMM yyyy", CultureInfo.InvariantCulture);
        }
        public void SelectDate(int year,  int month, int date)
        {
            this.ClickOnElement();
            DateTime currentDate = GetCurrentDate();
            //Only change month when neccessary
            if (year != currentDate.Year || month != currentDate.Month)
            {
                SelectMonthAndYear(year, month);
            }
            // DateBtn(date).ClickOnElement();
            this.ClickSubElement(DateBtn(date));
        }
        private void SelectMonthAndYear(int year, int month) 
        {
            _monthLayoutButton.ClickOnElement();
            int currentYear = Int32.Parse(_monthLayoutButton.WaitForElementToBeClickable().Text);
            if (year != currentYear)
            {
                SelectYear(year);
            }
            // MonthBtn(month).ClickOnElement();
            this.ClickSubElement(MonthBtn(month));
        }
        private void SelectYear(int year) {
            _monthLayoutButton.ClickOnElement();
            // SelectYearRange(year);
            SelectYearRange(year);
            // YearBtn(year).ClickOnElement();
            this.ClickSubElement(YearBtn(year));
        }
        private void SelectYearRange(int year){
           string yearRange = _monthLayoutButton.WaitForElementToBeClickable().Text;
            int minYear = Int32.Parse(yearRange.Split("-")[0].Trim());
            int maxYear = Int32.Parse(yearRange.Split("-")[1].Trim());
            while(year>maxYear){
                // _nextBtn.ClickOnElement();
                this.ClickSubElement(_nextBtn);
                //after click yearRangeLabel will change
                // yearRange = _monthLayoutButton.WaitForElementToBeClickable().Text;
                yearRange = this.WaitSubElementToBeVisible(_monthLayoutButton).Text;
                minYear = Int32.Parse(yearRange.Split("-")[0].Trim());
                maxYear = Int32.Parse(yearRange.Split("-")[1].Trim());
            }
            while(year<minYear){
                // _prevBtn.ClickOnElement();
                this.ClickSubElement(_prevBtn);
                ///after click yearRangeLabel will change
                // yearRange = _monthLayoutButton.WaitForElementToBeClickable().Text;
                yearRange = this.WaitSubElementToBeVisible(_monthLayoutButton).Text;
                minYear = Int32.Parse(yearRange.Split("-")[0].Trim());
                maxYear = Int32.Parse(yearRange.Split("-")[1].Trim());
            }
        }
        // private void ClickSubElement(WebObject subOject){
        //     var subWebElement = this.WaitForElementToBeVisible().FindElement(subOject.By);
        //     Wait().Until(ExpectedConditions.ElementToBeClickable(subWebElement)).Click();
        // }
    }
}