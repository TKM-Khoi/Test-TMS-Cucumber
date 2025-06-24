using Core.Element;
using Core.Reports;

using OpenQA.Selenium;

using Test.Components;

namespace Test.PageObjects
{
    public class CreateProjectPopup: BaseUserPage
    {
        #region element
        private WebObject _createBtn = new WebObject(By.XPath("//form[@id='newProject']//button[@id='btnConfirm']"), "Ok Button");
        private WebObject _cancelBtn = new WebObject(By.XPath(""), "Cancel Button");
        private WebObject _projectNameTxt = new WebObject(By.Id("name"), "Project Name Text Box");
        private WebObject _projectTypeDdl = new WebObject(By.Id("projecttype"), "Project Name Text Box");
        private WebObject ProjectTypeOpt(string type) => new WebObject(By.XPath($"//select[@id='projecttype']//option[text()='{type}']"), "Project Name Option");
        private WebObject _projectStatusDdl = new WebObject(By.XPath("//form[@id='newProject']//select[contains(@id, 'status')]"), "Project Status Dropdown List");
        private WebObject ProjectStatusOpt(string status) => new WebObject(By.XPath($"//form[@id='newProject']//select[contains(@id, 'status')]//option[text()='{status}']"), "Project Status Option");
        private CalendarObject _startDateDtp = new CalendarObject(By.XPath("//input[@name='sdate']/.."), name: "Start Date Calendar");
        private CalendarObject _endDateDtp = new CalendarObject(By.XPath("//input[@name='edate']/.."), name: "Start Date Calendar");
        private WebObject _sizeTxt = new WebObject(By.Id("sizeday"), "Size Text Box");
        private WebObject _locationDdl = new WebObject(By.XPath("//select[@id='location']"), "Location Dropdown List");
        private WebObject LocationOpt(string location) => new WebObject(By.XPath($"//form[@id='newProject']//select[contains(@id, 'location')]//option[text()='{location}']"), "Location Option");
        //TODO
        private WebObject _pmDdl = new WebObject(By.XPath("//select[@id='projectManager']"), "Project Manager Dropdown List");
        private WebObject PmOpt(string pm) => new WebObject(By.XPath($"//select[@id='projectManager']//option[text()='{pm}']"), "Project Manager Option");
        private WebObject _dpmDdl = new WebObject(By.XPath("//select[@id='deliveryManager']"), "Project Manager Dropdown List");
        private WebObject DpmOpt(string dm) => new WebObject(By.XPath($"//select[@id='deliveryManager']//option[text()='{dm}']"), "Project Manager Option");
        private WebObject _egmDdl = new WebObject(By.XPath("//select[@id='engagementManager']"), "Project Manager Dropdown List");
        private WebObject EgMOpt(string EgM) => new WebObject(By.XPath($"//select[@id='engagementManager']//option[text()='{EgM}']"), "Project Manager Option");
        private WebObject _shortDescTxa=new WebObject(By.XPath("//textarea[@id='shortDescription']"), "Short Descrpition Text Area");
        private WebObject _longDescTxa=new WebObject(By.XPath("//textarea[@id='longDescription']"), "Long Descrpition Text Area");
        private WebObject _technologyTxa=new WebObject(By.XPath("//textarea[@id='technologies']"), "Technologies Text Area");
        private WebObject _clientNameTxt=new WebObject(By.XPath("//input[@id='clientName']"), "Short Descrpition Text Box");
        private WebObject _clientIndustrySectorDdl = new WebObject(By.XPath("//select[@id='clientindustry']"), "Client Industry/Sector Dropdown List");
        private WebObject ClientIndustrySectorOpt(string industry) => new WebObject(By.XPath($"//select[@id='clientindustry']//option[@label='{industry}']"), "Client Industry/Sector Option");
        private WebObject _clientDescTxa=new WebObject(By.XPath("//textarea[@id='clientdescription']"), "Client Description Text Area");

        #endregion
        #region action
        public void EnterProjectName(string projectName)
        {
            ExtentReportHelper.LogInfo($"{_projectNameTxt.Name} enter {projectName}");
            _projectNameTxt.EnterText(projectName);
        }
        public void SelectStartDate(int year, int month, int day)
        {
            ExtentReportHelper.LogInfo($"{_startDateDtp.Name} select {year}-{month}-{day}");
            _startDateDtp.SelectDate(year, month, day);
        }
        public void SelectEndDate(int year, int month, int day)
        {
            ExtentReportHelper.LogInfo($"{_endDateDtp.Name} select {year}-{month}-{day}");
            _endDateDtp.SelectDate(year, month, day);
        }
        public void SelectProjectType(string type)
        {
            ExtentReportHelper.LogInfo($"{_projectTypeDdl.Name} select {type}");
            _projectTypeDdl.ClickOnElement();
            ProjectTypeOpt(type).ClickOnElement();
            _projectTypeDdl.ClickOnElement();
        }
        public void SelectProjectStatus(string status)
        {
            ExtentReportHelper.LogInfo($"{_projectStatusDdl.Name} select {status}");
            _projectStatusDdl.ClickOnElement();
            ProjectStatusOpt(status).ClickOnElement();
            _projectStatusDdl.ClickOnElement();
        }
        public void EnterSize(string size)
        {
            ExtentReportHelper.LogInfo($"{_sizeTxt.Name} enter {size}");
            _sizeTxt.EnterText(size);
        }
        public void SelectLocation(string location)
        {
            ExtentReportHelper.LogInfo($"{_locationDdl.Name} select {location}");
            _locationDdl.ClickOnElement();
            LocationOpt(location).ClickOnElement();
            _locationDdl.ClickOnElement();
        }
        //TODO
        public void SelectPM(string pm)
        {
            ExtentReportHelper.LogInfo($"{_pmDdl.Name} select {pm}");
            _pmDdl.ClickOnElement();
            PmOpt(pm).ClickOnElement();
            _pmDdl.ClickOnElement();
        }
        public void SelectDPM(string dpm)
        {
            ExtentReportHelper.LogInfo($"{_dpmDdl.Name} select {dpm}");
            _dpmDdl.ClickOnElement();
            DpmOpt(dpm).ClickOnElement();
            _dpmDdl.ClickOnElement();
        }
        public void SelectEgM(string egm)
        {
            ExtentReportHelper.LogInfo($"{_egmDdl.Name} select {egm}");
            _egmDdl.ClickOnElement();
            EgMOpt(egm).ClickOnElement();
            _egmDdl.ClickOnElement();
        }
        public void EnterShortDesc(string shortDesc){
            ExtentReportHelper.LogInfo($"{_shortDescTxa.Name} select {shortDesc}");
            _shortDescTxa.EnterText(shortDesc);
        }
        public void EnterLongDesc(string longDesc){
            ExtentReportHelper.LogInfo($"{_longDescTxa.Name} select {longDesc}");
            _longDescTxa.EnterText(longDesc);
        }
        public void EnterTechnology(string tech){
            ExtentReportHelper.LogInfo($"{_technologyTxa.Name} select {tech}");
            _technologyTxa.EnterText(tech);
        }
        public void EnterClientName(string clientName){
            ExtentReportHelper.LogInfo($"{_clientNameTxt.Name} select {clientName}");
            _clientNameTxt.EnterText(clientName);
        }
        public void SelectClientIndustrySector(string clientIndustrySector)
        {
            ExtentReportHelper.LogInfo($"{_clientIndustrySectorDdl.Name} select {clientIndustrySector}");
            _clientIndustrySectorDdl.ClickOnElement();
            ClientIndustrySectorOpt(clientIndustrySector).ClickOnElement();
            _clientIndustrySectorDdl.ClickOnElement();
        }
        public void EnterClientDesc(string clientDesc){
            ExtentReportHelper.LogInfo($"{_clientDescTxa.Name} select {clientDesc}");
            _clientDescTxa.EnterText(clientDesc);
        }
        public void ClickCreateBtn(){
            ExtentReportHelper.LogInfo($"Click {_createBtn.Name}");
            _createBtn.ClickOnElement();
        }
        #endregion
    }
}