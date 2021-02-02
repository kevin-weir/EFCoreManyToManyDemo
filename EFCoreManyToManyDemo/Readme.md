### Many To Many Table Mapping

The sample is written using Entity Framework and illustrates how to implement a many-to-many table relationship.  The tools used were **Visual Studio 2019 16.8.4** and **.NET 5.0 Core**


**Nuget Packages Used**

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools


**Setup Datbase**

To setup the database run the following command from the Nuget Package Manager Console:

```<language>
Update-Database
```

Note: 

> A SQL Server localdb file will be created and will contain the tables used by this example.



Also the following logic was added to the web.api startup to properly handle the recursive nature of the many to many relationship.

```<language>
    services.AddControllers()
        .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
```