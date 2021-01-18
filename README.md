# BlogSystemAPI

## .NET 5 RESTful Web API Project

1. Please go on to "appsettings.json" file and change your connection string credentials. You do not need to change Database name, it will create it after first run.
2. After first running application, if you see MSSQL has the tables and Database, please go to "appsettings.json" file and change "Migrate" to false.
  -Somehow if CodeFirst approach does not work for your system, Database Script "databaseScript.sql" file(in solution next to appsettings.json file) will help you to create all necessary sql.
3. First run will automaticly create a user with Username: "kaizen", Password: "1234". Password is stored hashed in db.
4. After these steps you can anytime start/stop the application without changing Database.
5. When you run the project again you will see Swagger API Documentation.
6. In Swagger, first of all go for "/api/Auth/Authenticate" and "Try it out" with username "kaizen" and password "1234". As a result you will get the user information with "token" parameter. Please copy that Token parameters value.
7. At the upper right corner of swagger ui, you will see Authorize button with a lock icon. Click on it. Then type "Bearer" and hit a space, then paste the token value and click Authorize button.
8. Now you have authenticated for all other endpoints.
9. Enjoy!
