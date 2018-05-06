# MilestoneTG.ApplicationInsights

[![Build](https://milestonetg.visualstudio.com/_apis/public/build/definitions/8468d2c8-8497-4e19-9420-4dfcb015c134/30/badge)](https://milestonetg.visualstudio.com/Milestone/_build/index?definitionId=30)
[![NuGet](https://img.shields.io/nuget/v/milestonetg.applicationinsights.svg?semVer=2.0.0)](https://www.nuget.org/packages/milestonetg.applicationinsights/)
[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/milestonetg/milestonetg-application-insights/master/LICENSE)

A collection of Telemetry Initializers for Microsoft Azure Application Insights.

* `VersionTelemetryInitializer`
* `Http4xxSuccessTelemetryInitializer`

## NuGet

The package currently targets NetStandard1.5 and Net45, supporting .Net Framework 4.5 and higher 
and .Net Core App 1.0 and higher.

https://www.nuget.org/packages/milestonetg.applicationinsights

## Documentation

### VersionTelemetryInitializer

`VersionTelemetryInitializer` sets the `TelemetryContext.Component.Version` property to your application's version. 
The default constructor will use the version of the entry assembly (your main executable).

``` cs
    TelemetryConfiguration.Active.TelemetryInitializers
        .Add(new VersionTelemetryInitializer());
``` 

You can explicitly specify the version by passing it into the constructor:

``` cs
    TelemetryConfiguration.Active.TelemetryInitializers
        .Add(new VersionTelemetryInitializer("1.0.0"));
``` 

You can also pass in an assembly or type in that assembly to derive the version from. In this case, it will use the 
`AssemblyName.Version` property as the application version:

``` cs
    TelemetryConfiguration.Active.TelemetryInitializers
        .Add(new VersionTelemetryInitializer(Assembly.Load("MyApi")));
``` 
or
``` cs
    TelemetryConfiguration.Active.TelemetryInitializers
        .Add(new VersionTelemetryInitializer(typeof(Startup)));
``` 



### Http4xxSuccessTelemetryInitializer

`Http4xxSuccessTelemetryInitializer` sets the `RequestTelemetry.Success` property to `true` if the response code is in 
the 4xx range. Specifically, >= 400 and < 500. By default, the Application Insights SDK sets this property to `false` 
for 4xx codes. If you're using 4xx codes for valid business responses, such as a 404 when a given entity isn't found, 
then this can create noise.

``` cs
    TelemetryConfiguration.Active.TelemetryInitializers
        .Add(new Http4xxSuccessTelemetryInitializer());
``` 

## Bugs and Feedback

For bugs, questions and discussions please use the 
[GitHub Issues](https://github.com/milestonetg/milestonetg-application-insights/issues).
