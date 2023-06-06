# Travel Blogger

### By Eusebie Siebenberg, Laura Hope, and Emma Gerigscott

<!-- ![gif of webpage in action](./PierresAuthenticTreats/wwwroot/img/pierreat.gif) -->

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

![image of schema connections](./TravelApi/wwwroot/img/travelSchema.png)

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

## Using This API
* Endpoints for this API are as follows:
```
Countries:
GET https://localhost:5001/api/countries/
GET https://localhost:5001/api/countries/{id}
POST https://localhost:5001/api/countries/
PUT https://localhost:5001/api/countries/{id}
DELETE https://localhost:5001/api/countries/{id}

Reviews:
GET https://localhost:5001/api/reviews/
POST https://localhost:5001/api/reviews/
GET https://localhost:5001/api/reviews/{id}

Users:
GET https://localhost:5001/api/users/
POST https://localhost:5001/api/users/
GET https://localhost:5001/api/users/{id}
PUT https://localhost:5001/api/users/{id}
DELETE https:///localhost:5001/users/{id}
PUT https:///localhost:5001/users/{userId}/reviews/{reviewId}
DELETE https:///localhost:5001/users/{userId}/reviews/{reviewId}

```
* In your terminal run ```dotnet watch run``` in the project directory.
* In your browser open https://localhost:5001/swagger/index.html
* Use the GUI to navigate the API

* Query Parameters for a GET Request on **Countries**: 

| Parameter  | Type   | Required     | Description                                      | Sample Url  |
|----------- |-----   | ---------    | -------------                                    | ----------  |
| Name       | String | not required | Returns countries with a matching name value     | https://locoalhost:5001/api/countries?name={COUNTRYNAME} |
| Language   | String | not required | Returns countries with a matching language value | https://locoalhost:5001/api/countries?language={LANGUAGE} |
| Climate    | String | not required | Returns countries with a matching climate value  | https://locoalhost:5001/api/countries?climate={CLIMATE} |
| Population | Int    | not required | Returns countries with a matching population value | https://locoalhost:5001/api/countries?population={NUMBER} |
| SortBy | string | not required | Sorts by "popular" or "unpopular" | https://localhost:5001/api/countries?sortBy={popular/unpopular} |
| Random | boolean | not required | Returns a random Country, Default is False | https://locoalhost:5001/api/countries?random={TRUE} |

* Query Parameters for a GET Request on **Reviews**: 

| Parameter  | Type   | Required     | Description                                      | Sample Url  |
|----------- |-----   | ---------    | -------------                                    | ----------  |
| Text       | String | not required | Returns reviews with matching text value     | https://locoalhost:5001/api/reviews?text={TEXTCONTENT} |
| CountryId   | Int | not required | Returns reviews with a matching countryId value | https://locoalhost:5001/api/reviews?countryId={Number} |
| Country Name    | String | not required | Returns reviews with matching country name  | https://locoalhost:5001/api/reviews?countryName={COUNTRYNAME} |
| UserId | Int    | not required | Returns reviews with a matching userId | https://locoalhost:5001/api/reviews?userId={NUMBER} |
| UserName | String    | not required | Returns reviews with a matching username | https://locoalhost:5001/api/reviews?userName={USERNAME} |
| Random | boolean | not required | Returns a random Review, Default is False | https://locoalhost:5001/api/reviews?random={TRUE} |



## Known Bugs



## License
[MIT](https://opensource.org/licenses/MIT)  
Copyright © 2023 Emma Gerigscott, Laura Hope, & Eusebie Siebenberg