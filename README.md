# TfL Coding Challenge
Find all the code here and instructions on how to run it.

## Language
This code was written in dotnet core Version: 2.1.402

## How to run the application
You first need to build the application. To do this, Navigate to the root folder and issue the following command

```bash
dotnet build
```
Now navigate to RoadStatus.Console folder and issue the following command

```bash
dotnet run A2
```
NOTE that the road name is optional.

## Testing the application
To run the tests, navigate to the RoadStatus.Tests folder and issue the following command

```bash
dotnet test
```

## Employing different config values
You have the option to change the following values:
- Api Id
- App Key
- Api Path

You can do this by editing the values in the appsettings.json file which can be found under the RoadStatus.Console folder.

