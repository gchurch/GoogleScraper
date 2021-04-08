# InfoTrack Tech Test

[![.NET](https://github.com/gchurch/TechTest/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/gchurch/TechTest/actions/workflows/dotnet.yml)

This application takes a search phrase and a URL. A Google search is made with the search phrase for the first 100 results. The positions that the given URL occurs in these search results is then displayed in a comma separated list. For example, the output of "1, 10, 33" means that the URL is present in the 1st 10th and 33rd search results. If the URL is not present in any of the search results then the output is "0".

The application I have created is an ASP.NET Core Web API and front-end Angular SPA. I use Selenium in order to get the HTML of the Google results pages so that I can scrape the URLs. I created a few services in order to separate concerns and make the code easier to unit test. I wrote a few unit tests and integration tests.

I have used .NET 5.0.

To run the application:
Open the solution in Visual Studio and press start.

In the UI, enter the search phrase and URL you want to use and then press the Search button.
