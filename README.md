# Bamboo Card

# Description

    Bamboo Card project was developed as part of Developer coding test using ASP.NET Core to implement a RESTful API to retrieve
    the details of the best n stories from the Hacker News API, as determined by their score, where 'n' is specified by the
    caller to the API.

# Prerequisites

    Visual Studio 2022 and .NET 6

# Steps to run

    1. Clone the repository to the local machine and open the solution file - BambooCard.sln in Visual Studio 2022.
    2. Install the below NuGet packages from NuGet Package Library:
         i. Newtonsoft.Json
        ii. AutoMapper
    3. The Hacker News API url is specified in appsettings.json for the 'n' beststories and the details of the stories using id.
    4. Build the project solution.
    5. In Visual Studio, press "Control + F5" to run the application.
    6. Access the API using the url below(port number may vary) and 2 is sample 'n':
        https://localhost:7020/api/BestStories/GetData/2

# Sample Output from Development environment:

    The API returns an array of the best n stories as returned by the Hacker News API in descending order of score as below:

![sample-api-output][def2]

[def2]: api-output.png
