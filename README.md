# Travel Blogger

### By Eusebie Siebenberg, Laura Hope, and Emma Gerigscott

## Description

Add a review on our travel API! Visit countries you've never heard of before and view all the reviews from these fantastical places!

## Technologies Used

* C#
* .NET
* ASP.NET Core
* MVC
* Entity Framework Core
* Pomelo Entity Framework Core
* EF Core Migrations
* Swashbuckle
* Swagger
* MySQL

## Database Structure

![schema](/TravelApi/wwwroot/img/travelShema.png)

## Database Setup Instructions

1. Clone this repo.
2. Open your terminal (e.g. Terminal or GitBash) and navigate to this project's directory called "TravelApi".
3. Set up the project:
  * Create a file called 'appsettings.json' in TravelApi.Solution/TravelApi directory
  * Add the following code to the appsettings.json file:
  ```
  {
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=travel_api;uid=[YOUR_SQL_USER_ID];pwd=[YOUR_SQL_PASSWORD];"
    }
  }
  ```
  * Make sure to plug in your SQL user id and password at ```[YOUR_SQL_USER_ID]``` and ```[YOUR_SQL_PASSWORD]```
4. Set up the database:
  * Make sure EF Core Migrations is installed on your computer by running ```dotnet tool install --global dotnet-ef --version 6.0.0```
  * In the production folder of the project (TravelApi.Solution/TravelApi) run:
  ```
  dotnet ef database update
  ```
  * You should see the new schema in your _Navigator > Schemas_ tab of your MySql Workbench on refresh called ```travel_api```

* In your terminal run ```dotnet watch run``` in the project directory.
* It should open automatically in your browser, if it does not, enter this url to access Swagger: https://localhost:5001/swagger/index.html 
* Use the GUI to navigate the API

## Using This API
* API Versioning is enabled, which defaults to API v2 when Swagger opens
* Simply use the Swagger **Select a definition** drop down options list to select API v1
* To access the API in **Postman**, us the URLs listed below for each endpoint. Similarly to access v1, you can change the endpoint as follows: GET https://localhost:5001/api/v1countries/
* **Pagination** is also enabled for this API. Endpoint examples for Page Number and Page Size are given below for Countries & Reviews to test this feature.
```
Countries:
GET https://localhost:5001/api/v2/countries/
GET https://localhost:5001/api/v2/countries/{id}
POST https://localhost:5001/api/v2/countries/
PUT https://localhost:5001/api/v2/countries/{id}
DELETE https://localhost:5001/api/v2/countries/{id}

Reviews:
GET https://localhost:5001/api/v2/reviews/
POST https://localhost:5001/api/v2/reviews/
GET https://localhost:5001/api/v2/reviews/{id}

Users:
GET https://localhost:5001/api/v2/users/
POST https://localhost:5001/api/v2/users/
GET https://localhost:5001/api/v2/users/{id}
PUT https://localhost:5001/api/v2/users/{id}
DELETE https:///localhost:5001/v2/users/{id}
PUT https:///localhost:5001/v2/users/{userId}/reviews/{reviewId}
DELETE https:///localhost:5001/v2/users/{userId}/reviews/{reviewId}

```
* Query Parameters for a GET Request on **Countries**: 

| Parameter  | Type   | Required     | Description                                      | Sample Url  |
|----------- |-----   | ---------    | -------------                                    | ----------  |
| Countries | List | not required | Returns a list of all countries in database | https://localhost:5001/api/v2/countries |
| Name       | String | not required | Returns countries with a matching name value     | https://localhost:5001/api/v2/countries?name={COUNTRYNAME} |
| Language   | String | not required | Returns countries with a matching language value | https://localhost:5001/api/v2/countries?language={LANGUAGE} |
| Climate    | String | not required | Returns countries with a matching climate value  | https://localhost:5001/api/v2/countries?climate={CLIMATE} |
| Population | Int    | not required | Returns countries with a matching population value | https://localhost:5001/api/v2/countries?population={NUMBER} |
| SortBy | string | not required | Sorts by "popular" or "unpopular" | https://localhost:5001/api/v2/countries?sortBy={popular/unpopular} |
| Random | boolean | not required | Returns a random Country, Default is False | https://localhost:5001/api/v2/countries?random={TRUE} |
| Page Number + Page Size | int, int | not required | Returns countries with user selected page number & page size | https://localhost:5001/api/v2/countries?pageNumber={PAGENUMBER}&pageSize={PAGESIZE} |

* Query Parameters for a GET Request on **Reviews**: 

| Parameter  | Type   | Required     | Description                                      | Sample Url  |
|----------- |-----   | ---------    | -------------                                    | ----------  |
| Reviews | List | not required | Returns a list of all reviews in database | https://localhost:5001/api/v2/reviews |
| Text       | String | not required | Returns reviews with matching text value     | https://localhost:5001/api/v2/reviews?text={TEXTCONTENT} |
| CountryId   | Int | not required | Returns reviews with a matching countryId value | https://localhost:5001/api/v2/reviews?countryId={Number} |
| Country Name    | String | not required | Returns reviews with matching country name  | https://localhost:5001/api/v2/reviews?countryName={COUNTRYNAME} |
| UserId | Int    | not required | Returns reviews with a matching userId | https://localhost:5001/api/v2/reviews?userId={NUMBER} |
| UserName | String    | not required | Returns reviews with a matching username | https://localhost:5001/api/v2/reviews?userName={USERNAME} |
| Random | boolean | not required | Returns a random Review, Default is False | https://localhost:5001/api/v2/reviews?random={TRUE} |
| Page Number + Page Size | int, int | not required | Returns reviews with user selected page number & page size | https://localhost:5001/api/v2/reviews?pageNumber={PAGENUMBER}&pageSize={PAGESIZE} |

* Query Parameters for a GET Request on **Users**:

| Parameter  | Type   | Required     | Description                                      | Sample Url  |
|----------- |-----   | ---------    | -------------                                    | ----------  |
| Users | List | not required | Returns a list of all users in database | https://localhost:5001/api/v2/users |
| User Name | String | not required | Returns a user with matching user name  | https://localhost:5001/api/v2/sers?username={USERNAME} |
| UserId | int | not required | Returns a user with matching userId | https://localhost:5001/api/v2/users/{NUMBER} |


## Known Bugs

No known bugs as of 6/7/23

## [MIT](https://opensource.org/license/mit/) License 

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Copyright © 2023 Emma Gerigscott, Laura Hope, & Eusebie Siebenberg