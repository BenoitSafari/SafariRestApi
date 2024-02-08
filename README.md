## Dotnet Rest API Boilerplate

### Env

_Create a `appsettings.Development.json` file in the `<project>.API` project._

```json
{
  "ConnectionStrings": {
    "Default": "Host=localhost;Database=<db_name>;Username=<db_user>;Password=<db_password>;Port=<port>",
  },
  "AllowedHosts": "*",
  "CorsAllowedOrigins": ["http://localhost:3000"],
  "passwordRegex": "^(?=.*[A-Z])(?=.*[!#$%*+=?|\\-])(?=.*\\d)[!#$%*+=?|\\-A-Za-z\\d]{12,}$"
}
```

### Recommended VSCode extensions

- csharpier.csharpier-vscode
- ms-dotnettools.csdevkit
- ms-dotnettools.csharp
