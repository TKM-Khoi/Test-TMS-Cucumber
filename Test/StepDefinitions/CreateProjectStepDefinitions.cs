using FluentAssertions;
using FluentAssertions.Execution;

using Reqnroll;

using Service.DTOs;

using Test.PageObjects;

namespace Test.StepDefinitions;

[Binding]
public sealed class CreateProjectStepDefinitions
{
    private CreateProjectPopup _createProjectPopup;
    private ScenarioContext _scenarioContext;
    private ProjectDetailPage _projectDetailPage;

    public CreateProjectStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _createProjectPopup = new CreateProjectPopup();
        _projectDetailPage = new ProjectDetailPage();
    }
    [When("user click Create button")]
    public void StepUserClickCreateButton()
    {
        _createProjectPopup.ClickCreateBtn();
    }
    [When("user entered all the fields with the following datas")]
    public void StepUserEnteredAllTheFieldsWithTheFollowingDatas(DataTable table)
    {
        CreateProjectDto dto = table.CreateInstance<CreateProjectDto>();
        _scenarioContext.Set(dto, "createProject");
        _createProjectPopup.EnterProjectName(dto.Name);
        _createProjectPopup.SelectProjectType(dto.Type);
        _createProjectPopup.SelectProjectStatus(dto.Status);
        _createProjectPopup.SelectStartDate(dto.StartDate.Year, dto.StartDate.Month, dto.StartDate.Day);
        _createProjectPopup.SelectEndDate(dto.EndDate.Year, dto.EndDate.Month, dto.EndDate.Day);
        _createProjectPopup.EnterSize(dto.SizeInDays.ToString());
        _createProjectPopup.SelectLocation(dto.Location);
        _createProjectPopup.SelectPM(dto.PM);
        _createProjectPopup.SelectDPM(dto.DPM);
        _createProjectPopup.SelectEgM(dto.EM);
        _createProjectPopup.EnterShortDesc(dto.ShortDescription);
        _createProjectPopup.EnterLongDesc(dto.LongDescription);
        _createProjectPopup.EnterTechnology(dto.Technologies);
        _createProjectPopup.EnterClientName(dto.ClientName);
        _createProjectPopup.SelectClientIndustrySector(dto.ClientIndustrySector);
        _createProjectPopup.EnterClientDesc(dto.ClientDescription);

    }

    [Then("created project detail is shown")]
    public void StepCreatedProjectDetailIsShown()
    {
        CreateProjectDto actualCreatedProject = _projectDetailPage.GetCreatedProject();
        CreateProjectDto expectedCreatedProject = _scenarioContext.Get<CreateProjectDto>("createProject");
        using (new AssertionScope())
        {
            expectedCreatedProject.Should().BeEquivalentTo(actualCreatedProject, opt =>
                opt.Excluding(e => e.PM).Excluding(e => e.DPM).Excluding(e => e.EM)
            );
            expectedCreatedProject.PMFullInfo.Should().Be(actualCreatedProject.PMFullInfo);
            expectedCreatedProject.DPMFullInfo.Should().Be(actualCreatedProject.DPMFullInfo);
            expectedCreatedProject.EMFullInfo.Should().Be(actualCreatedProject.EMFullInfo);
        }
    }
}