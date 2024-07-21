# AspNET Crud API Example
 An Simple Crud With 2 entities: Clients and Employees, where whe use ASP.NET and Microsoft SQL Server. We also use the one to many in the relation of employees and clients, where one employee has many clients;

## Database Connection
 Open the project in the Visual Studio/Visual Studio code and navigate to the folder `ApiCrudClientes` and find the `appsettings.json`.
 After that, go to your SSMS and copy the connection url, paste it in the `YOUR SERVER HERE` *in the code is something like that:* "Server=YOUR SERVER HERE;Database=ApiCRUD;Trusted_connection=true;TrustServerCertificate=true;"

### Migration
To migrate the entities to your SSMS, open the Package Manager Console in your Visual Studio and write: `update-database`
