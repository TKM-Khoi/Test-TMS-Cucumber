Feature: Create Project
This feature I will set precondition using tag

  @web @createProject
  Scenario: Create Project successfully
    When user entered all the fields with the following datas
      | Field                | Value                                                 |
      | Name                 | Alpha aaaaaaaaaaaaaaaaaaa                             |
      | Type                 | Fixed Price                                           |
      | Status               | Closed                                                |
      | StartDate            |                                            2024-06-01 |
      | EndDate              |                                            2024-07-01 |
      | SizeInDays           |                                                    30 |
      | Location             | Offshore Vietnam Ho Chi Minh city                     |
      | PM                   | Duc Le (20)                                           |
      | PMFullInfo           | Duc Le                                                |
      | DPM                  | Manh Le (25)                                          |
      | DPMFullInfo          | Manh Le                                               |
      | EM                   | Manh Le (25)                                          |
      | EMFullInfo           | Manh Le                                               |
      | ShortDescription     | Internal portal revamp                                |
      | LongDescription      | Redesigning a responsive web portal for internal use. |
      | Technologies         | .NET, React                                           |
      | ClientName           | Acme Corp                                             |
      | ClientIndustrySector | Energy                                                |
      | ClientDescription    | A leading investment services company.                |
    And user click Create button
    Then created project detail is shown
