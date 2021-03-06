#tool "nuget:https://www.nuget.org/api/v2?package=JetBrains.ReSharper.CommandLineTools&version=2018.1.0"
#addin "Cake.DocFx"
#tool "docfx.console"


var target = Argument("target", "Default");
var configuration = Argument<string>("configuration", "Release");

var projects = GetFiles("./**/*.csproj");
var projectPaths = projects.Select(project => project.GetDirectory().ToString());
var artifactsDir = "./Artifacts";
var coverageThreshold = 100;

Setup(context =>
{
    Information("Running tasks...");
});

Teardown(context =>
{
    Information("Finished running tasks.");
});

Task("Clean")
    .Description("Cleans all directories that are used during the build process.")
    .Does(() =>
{
    var settings = new DeleteDirectorySettings {
        Recursive = true,
        Force = true
    };
    // Clean solution directories.
    foreach(var path in projectPaths)
    {
        Information($"Cleaning path {path} ...");
        var directoriesToDelete = new DirectoryPath[]{
            Directory($"{path}/obj"),
            Directory($"{path}/bin")
        };
        foreach(var dir in directoriesToDelete)
        {
            if (DirectoryExists(dir))
            {
                DeleteDirectory(dir, settings);
            }
        }
    }
    // Delete artifact output too
    if (DirectoryExists(artifactsDir))
    {
        Information($"Cleaning path {artifactsDir} ...");
        DeleteDirectory(artifactsDir, settings);
    }
});

Task("Restore")
    .Description("Restores all the NuGet packages that are used by the specified solution.")
    .Does(() =>
{
    // Restore all NuGet packages.
    foreach(var path in projectPaths)
    {
        Information($"Restoring {path}...");
        DotNetCoreRestore(path);
    }
});

Task("Build")
    .Description("Builds all the different parts of the project.")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
     {
         Framework = "netcoreapp2.1",
         Configuration = "Release",
         OutputDirectory = artifactsDir
     };

     DotNetCoreBuild("./src/backend/Workshop.Api/Workshop.Api.csproj", settings);
});

///////////////////////////////////////////////////////////////////////////////
// Unit Tests
///////////////////////////////////////////////////////////////////////////////

Task("Test")
    .Description("Run all unit tests within the project.")
    .Does(() =>
{
    // Calculate code coverage
    var settings = new DotNetCoreTestSettings
     {
         ArgumentCustomization = args => args.Append("/p:CollectCoverage=true")
                                             .Append("/p:CoverletOutputFormat=opencover")
                                             .Append("/p:ThresholdType=line")
                                             .Append($"/p:Threshold={coverageThreshold}")
     };
    DotNetCoreTest("./src/backend/tests/Workshop.CarHelp.Tests/Workshop.CarHelp.Tests.csproj", settings);
    DotNetCoreTest("./src/backend/tests/Workshop.Cars.Tests/Workshop.Cars.Tests.csproj", settings);
    DotNetCoreTest("./src/backend/tests/Workshop.Integration.Tests/Workshop.Integration.Tests.csproj", settings);
});

///////////////////////////////////////////////////////////////////////////////
// Validations
///////////////////////////////////////////////////////////////////////////////

Task("DupFinder")
    .Description("Find duplicates in the code")
    .Does(() =>
{
    var settings = new DupFinderSettings() {
        ShowStats = true,
        ShowText = true,
        OutputFile = $"{artifactsDir}/dupfinder.xml",
        ExcludeCodeRegionsByNameSubstring = new string [] { "DupFinder Exclusion" },
        ThrowExceptionOnFindingDuplicates = false
    };
    DupFinder("./Workshop.sln", settings);
});

Task("InspectCode")
    .Description("Inspect the code using Resharper's rule set")
    .Does(() =>
{
    var settings = new InspectCodeSettings() {
        SolutionWideAnalysis = true,
        OutputFile = $"{artifactsDir}/inspectcode.xml",
        ThrowExceptionOnFindingViolations = false
    };
    InspectCode("./Workshop.sln", settings);
});

Task("Validate")
    .Description("Validate code quality using Resharper CLI. tools.")
    .IsDependentOn("DupFinder")
    .IsDependentOn("InspectCode");

///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

Task("Doc")
	.Does(() => 
	{
		DocFxMetadata("./docfx_project/docfx.json");
		DocFxBuild("./docfx_project/docfx.json");
		DocFxServe("./docfx_project/_site");
	});

///////////////////////////////////////////////////////////////////////////////
// Full run
///////////////////////////////////////////////////////////////////////////////

Task("full")
    .Description("Build the code, test and validate")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Validate")
	.IsDependentOn("Doc");

///////////////////////////////////////////////////////////////////////////////
// TARGETS
///////////////////////////////////////////////////////////////////////////////

Task("Default")
    .Description("This is the default task which will be ran if no specific target is passed in.")
    .IsDependentOn("Test")
    .IsDependentOn("Validate");


///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);