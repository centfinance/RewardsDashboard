# RewardsDashboard
Dashboard for querying and exporting payment files in conjunction with the rewards daemon.

# Pre-steps
This dashboard uses the .NET 6 framework which can be installed from the [.NET Core website](https://dotnet.microsoft.com/en-us/download).

To confirm that you have .NET 6 installed, open a terminal and type the following.

```
dotnet --info
```

This project can be built using the .NET Core command line tools or popular .NET IDE's including [Visual Studio](https://visualstudio.microsoft.com/), [Visual Code IDE's](https://code.visualstudio.com/) or [Jet Brains Rider](https://www.jetbrains.com/rider/).

This dashboard uses the Telerik Blazor control set. A trial can be downloaded or full version purchased from [the Telerik website](https://www.telerik.com/blazor-ui).

For development purposes you should store database connection details using the .NET Secret Manager tool.
If you were creating a new project you would initialise the secret manager for the project using the following.

```
dotnet user-secrets init
```

However, we have already initialised the secret manager for this project and so you should create a secrets file in the following location.

Windows
```
%APPDATA%\Microsoft\UserSecrets\b866d011-7a0d-4c9b-b026-fe1d2fde35c7\secrets.json
```

Linux/Mac
```
~/.microsoft/usersecrets/b866d011-7a0d-4c9b-b026-fe1d2fde35c7/secrets.json
```

Within this file you will need to store the following secrets for your target database.
```
{
  "RewardsDatabase:UserID": "<username>",
  "RewardsDatabase:DataSource": "<server URL>",
  "RewardsDatabase:Password": "<password>",
  "RewardsDatabase:InitialCatalog": "<database name>"
}
```

# Build and deploy
This project can be built and deployed to a IIS, a docker container, straight to Azure or to any other host that supports .NET Core.
