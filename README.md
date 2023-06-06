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

![image of schema connections](../TravelApi.Solution/TravelApi/wwwroot/img/travelSchema.png)

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
GET http://localhost:5000/api/countries/
GET http://localhost:5000/api/countries/{id}
POST http://localhost:5000/api/countries/
PUT http://localhost:5000/api/countries/{id}
DELETE http://localhost:5000/api/countries/{id}
GET http://localhost:5000/api/reviews/
POST http://localhost:500/api/reviews/
```
* In your terminal run ```dotnet watch run``` in the project directory.
* In your browser open https://localhost:5001/swagger/index.html
* Use the GUI to navigate the API

* Query Parameters for a GET Request on Countries: 

| Parameter  | Type   | Required     | Description                                      |
|----------- |-----   | ---------    | -------------                                    |
| Name       | String | not required | Returns countries with a matching name value     |
| Language   | String | not required | Returns countries with a matching language value |
| Climate    | String | not required | Returns countries with a matching climate value  |
| Population | Int    | not required | Returns countries with a matching population value |


## Known Bugs

* _No users...yet_

## License
[MIT](https://opensource.org/licenses/MIT)  
Copyright © 2023 Emma Gerigscott, Laura Hope, & Eusebie Siebenberg