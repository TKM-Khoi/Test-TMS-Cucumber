Feature: Search Project
This feature I will set precondition using BackGround

  Background:
    Given user logins with username "admin" and password "admin"
    And user go to Search Project page

  @web @search
  Scenario: Search Project successfully
    Given user enter "<name>" into Project Name field
    And user select "<location>" in Location field
    And user select "<type>" in Project Type field
    And user click Search button
    Then all the searched Projects match the entered criterias

    Examples:
      | name | location                          | type           |
      | test |                                   |                |
      |      | Offshore Vietnam Hanoi            |                |
      |      | Offshore Vietnam Ho Chi Minh city |                |
      |      |                                   | Fixed Price    |
      |      |                                   | ODC            |
      |      |                                   | Time& Material |
      | Test | Offshore Vietnam Hanoi            | ODC            |

  @web @search
  Scenario: Search Project does not found
    Given user enter "<name>" into Project Name field
    And user select "<location>" in Location field
    And user select "<type>" in Project Type field
    And user click Search button
    Then No Result warning message show

    Examples:
      | name                                          | location | type |
      | yasssssssssssssssssuuuuuuuuuuuuuuoooooooooooo |          |      |
