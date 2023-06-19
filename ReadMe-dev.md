# GOTCHAS #

## Creating a new data model ##

1. Create/Change \<model\>.cs file

2. Build a model (Change name to the specific model)
    ```
    dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovie.Data.MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite
    ```

| **Parameter**              | **Description**                                                         |
|----------------------------|-------------------------------------------------------------------------|
| -m                         | The name of the model.                                                  |
| -dc                        | The data context.                                                       |
| --relativeFolderPath       | The relative output folder path to create the files.                    |
| --useDefaultLayout\|-udl   | The default layout should be used for the views.                        |
| --referenceScriptLibraries | Adds `_ValidationScriptsPartial` to Edit and Create pages.              |
| -sqlite                    | Flag to specify if `DbContext` should use SQLite instead of SQL Server. |

3. Migration to create and update the database to match the data model
    ```
    dotnet ef migrations add InitialCreate
    ```
    ```
    dotnet ef database update
    ```

4. Test app