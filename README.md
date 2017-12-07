# Selenium.Net

This simple sample shows how to integrate Selenium Web Driver with a .Net Core MVC Project.

## How to run

* Open the DistanceConverter.sln and SeleniumNet.sln in two separated instances of Visual Studio 2017 and rebuild the application to restore the nuget packages, and the run the DistanceConverter MVC application.

### SeleniumNet Project
* Check the appsettings.json and configure the directories of the webdrivers of the browsers to a specific local folder and the URL of the DistanceConverter project.
* Open the TestExplorer window to see the tests that were created and run then. For each specific browser, a new instance of the browser in test will be opened and closed for each InlineData.
* Run the tests and check the results.

## Features

* Both projects are in .Net Standard 2.0.
* SeleniumNet uses Selenium.WebDriver, Selenium.Support and Selenium.WebDriverBackedSelenium Nuget packages to implement Web Interface tests.
* xUnit for Unit Tests

### WebDrivers

* The SeleniumDrivers folder has the drivers for Chrome, Edge, IE and Firefox
