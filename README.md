# TrueLayer_API_Test

API Test Automation

## Getting started

1. Install latest .Net Core 3.1 - <https://dotnet.microsoft.com/download> as well as the 3.1.102 SDK
2. Open a command window or powershell
3. Restore Dependancies. ```sh $ dotnet restore```
4. Run tests. ```sh $ dotnet test```

## Test Reports

Tests are logged to a .trx file which is the default Microsoft standard, these provide nice visual reports when viewed in Visual Studio, Azure DevOps or Visual Studio Code with the approprate plugin.

## CICD

Test will run in Azure DevOps using azure-pipelines.yml, tests will automaticly get logged as part of the test run

## Observations

Documentation says position API supports a maximum of 10 timestamps per request, 11 were handled without issue, needs investigation into the actual limit before updating the documentation

## Part 2

### Gaps in the process

Team A:
- Tests are all E2E, should be testing as possible at the rest API level, resurving UI testing for UI specific functionality and a few E2E tests as a Sanity check
- Tests run overnight, this is a slow feedback loop if code is deployed early in the day, I would assume this is done due to the time taken for the tests to run. In the first instance I would look to run a few key tests from the test suite on deployment to the dev environment as a sanity check and then look to move as much testing as possible to the API layer for faster feedback
- Application supports 2 browsers (Chrome and Safari) however the test suite only supports Chrome and FireFox. It would be useful to have tests running against Safari as well. Due to the time invested in the current test suite, I would recommend a smaller suite using a framework which supports Safari for sanity checking, this could also be used to sanity check on deployments fo the dev environment, leving the full suite of tests running overnight.

Team B:
- Not all work is documented in Jira meaning there is always a record of what has been built or tested.


### Working with both teams

- Attend all planning sessions making sure everyone is clear on what is needed to be tested as part of upcoming work. Work with Product Managers to mack sure requirements and expectations are clear and understood by everyone. Pair with engineers when writing tests and review tests that have been written. Add tests for edge cases that may not have been considered when features where originally developed. Work with Engineering Managers to optimise CI systems to provide feedback as fast as possible
