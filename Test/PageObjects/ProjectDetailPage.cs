using System;

using Core.Element;

using OpenQA.Selenium;

using Service.DTOs;

using Test.Const;

namespace Test.PageObjects
{
    public class ProjectDetailPage: BaseUserPage
    {
        private WebObject _deleteBtn = new WebObject(By.XPath("//button[@id='btnDelete'][@type='submit']"), "Delete Button");
        private WebObject _confirmDeleteBtn = new WebObject(By.XPath("//form[@id='deleteProjectRole']//button[@id='btnConfirm'][@type='submit']"), "Delete Confirm Button");
        private WebObject _deleteSuccessfullyToast =new WebObject(By.XPath($"//span[text()='{MessageConst.DELETE__SUCCESSFULLY_MSG}']"),"Delete Successfully Toast");
        private WebObject _NameLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='name']/../p"), "Project Name label");
        private WebObject _TypeLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='type']/../p"), "Project Type label");
        private WebObject _StatusLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='status']/../p"), "Project Type label");
        private WebObject _StartDateLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='startDate']/../p"), "Project Type label");
        private WebObject _EndDateLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='endDate']/../p"), "Project Type label");
        private WebObject _SizeLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='sizeday']/../p"), "Project Type label");
        private WebObject _LocationLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='location']/../p"), "Project Type label");
        private WebObject _PmLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='projectManager']/../p"), "Project Type label");
        private WebObject _DpmLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='deliveryManager']/../p"), "Project Type label");
        private WebObject _EmLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='engagementManager']/../p"), "Project Type label");
        private WebObject _ShortDescLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='shortDescription']/../p"), "Project Type label");
        private WebObject _LongDescLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='longDescription']/../p"), "Project Type label");
        private WebObject _TechnologiesLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='technologies']/../p"), "Project Type label");
        private WebObject _ClientNameLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='clientName']/../p"), "Project Type label");
        private WebObject _ClientIndustrySectorLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='clientindustry']/../p"), "Project Type label");
        private WebObject _ClientDescLbl = new WebObject(By.XPath("//div[@ng-include=\"'viewMode'\"]//label[@for='clientdescription']/../p"), "Project Type label");

        
        private void ClickDeleteBtn()
        {
            _deleteBtn.ClickOnElement();
        }
        private void ClickConfirmDeleteBtn(){
            _confirmDeleteBtn.ClickOnElement();
        }
        public CreateProjectDto GetCreatedProject()
        {
            return new CreateProjectDto
            {
                Name = _NameLbl.GetTextFromElement(),
                Type = _TypeLbl.GetTextFromElement(),
                Status = _StatusLbl.GetTextFromElement(),
                StartDate = DateTime.Parse(_StartDateLbl.GetTextFromElement()),
                EndDate = DateTime.Parse(_EndDateLbl.GetTextFromElement()),
                SizeInDays = Int32.Parse(_SizeLbl.GetTextFromElement()),
                Location = _LocationLbl.GetTextFromElement(),
                PMFullInfo = _PmLbl.GetTextFromElement(),
                DPMFullInfo = _DpmLbl.GetTextFromElement(),
                EMFullInfo = _EmLbl.GetTextFromElement(),
                ShortDescription = _ShortDescLbl.GetTextFromElement(),
                LongDescription = _LongDescLbl.GetTextFromElement(),
                Technologies = _TechnologiesLbl.GetTextFromElement(),
                ClientName = _ClientNameLbl.GetTextFromElement(),
                ClientIndustrySector = _ClientIndustrySectorLbl.GetTextFromElement(),
                ClientDescription = _ClientDescLbl.GetTextFromElement()
            };
        }
        public void DeleteProject()
        {
            ClickDeleteBtn();
            ClickConfirmDeleteBtn();
            _deleteSuccessfullyToast.WaitForElementToBeVisible();
        }
    }
}