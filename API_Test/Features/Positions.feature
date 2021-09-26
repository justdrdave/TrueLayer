@Positions 
Feature: Positions

  As an automation tester
  I want to provide a couple of working tests
  So that I can demonstrate the automation working
 
  Scenario: Get ISS position with no timestamp
    Given I wish to query the ISS position
    When I submit a GET to the position API with   parameters
    Then I should get a 400 response

   Scenario Outline: Get ISS position with timestamps and optional units
    Given I wish to query the ISS position
    When I submit a GET to the position API with <parameters> parameters
    Then I should get a 200 response
    And I should get the expected position data
    Scenarios: 
    | parameters                                                                                                                |
    | ?timestamps=1436029892                                                                                                    |
    | ?timestamps=1436029892,1436029902                                                                                         |
    | ?timestamps=1436029892,1436029902&units=miles                                                                             |
    | ?timestamps=1436029892,1436029902,1436039892,1436039902,1436049892,1436049902,1436059892,1436059902,1436069892,1436069902 |

  # This test should fail based on the API documentation putting a limit of 10 timestamps in the query string
  Scenario Outline: Get More then 10 timestamps are not supported
    Given I wish to query the ISS position
    When I submit a GET to the position API with <parameters> parameters
    Then I should get a 200 response
    And I should get the expected position data
    Scenarios: 
    | parameters                                                                                                                           |
    | ?timestamps=1436029892,1436029902,1436039892,1436039902,1436049892,1436049902,1436059892,1436059902,1436069892,1436069902,1632654896 |

# Only ISS currently supported by API
Scenario Outline: Get SkyLab position with timestamps and optional units
    Given I wish to query the SkyLab position
    When I submit a GET to the position API with <parameters> parameters
    Then I should get a 404 response
    Scenarios: 
    | parameters                                                                                                                |
    | ?timestamps=1436029892                                                                                                    |
