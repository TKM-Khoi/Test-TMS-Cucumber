Feature: Login

  @web @login
  Scenario: Login successfully
    Given user go to login page
    When user enter "<username>" into Username field
    And user enter "<password>" into password field
    And user click Login button
    Then user go to Search Employee page

    Examples:
      | username | password |
      | Admin2   | Fxu1tw^E |

  @web @login
  Scenario: Login with empty username unsuccessfully
    Given user go to login page
    When user enter "<username>" into Username field
    And user enter "<password>" into password field
    And user click Login button
    Then user see empty username warning message

    Examples:
      | username | password |
      |          | qp$#tGu^ |

  @web @login
  Scenario: Login with empty password unsuccessfully
    Given user go to login page
    When user enter "<username>" into Username field
    And user enter "<password>" into password field
    And user click Login button
    Then user see empty password warning message

    Examples:
      | username | password |
      | Admin2   |          |

  @web @login
  Scenario: Login with empty username and password unsuccessfully
    Given user go to login page
    When user enter "<username>" into Username field
    And user enter "<password>" into password field
    And user click Login button
    Then user see empty username password warning message

    Examples:
      | username | password |
      |          |          |

  @web
  Scenario: Login with incorrect username and password unsuccessfully
    Given user go to login page
    When user enter "<username>" into Username field
    And user enter "<password>" into password field
    And user click Login button
    Then user see wrong username password warning message

    Examples:
      | username | password |
      | Admin1   | qp$#tGu^ |
