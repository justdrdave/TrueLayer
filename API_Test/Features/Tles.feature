@TLES 
Feature: TLES

  As an automation tester
  I want to provide a couple of working tests
  So that I can demonstrate the automation working

   Scenario Outline: Get ISS tles with optional formats
    Given I wish to query the ISS tles
    When I submit a GET to the tles API with <format> format
    Then I should get a 200 response
    And I should get the expected tles data
    Scenarios: 
    | format       |
    |              |
    | ?format=json |
    | ?format=text |

  # Only ISS currently supported by API
  Scenario: Get SkyLab tles with optional formats
    Given I wish to query the SkyLab tles
    When I submit a GET to the tles API with  format
    Then I should get a 404 response
