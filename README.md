# Milestone.ApplicationInsights

[![Build](https://milestonetg.visualstudio.com/_apis/public/build/definitions/8468d2c8-8497-4e19-9420-4dfcb015c134/26/badge)](https://milestonetg.visualstudio.com/Milestone/_build/index?definitionId=26)
[![NuGet](https://img.shields.io/nuget/vpre/NHystrix.svg?semVer=2.0.0)](https://www.nuget.org/packages/milestonetg.applicationinsights/)
[![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/milestonetg/milestonetg-application-insights/master/LICENSE)

A collection of Telemetry Initializers for Application Insights.

* `VersionTelemetryInitializer`
* `Http4xxSuccessTelemetryInitializer`

## NuGet

The package currently targets NetStandard2.0.

https://www.nuget.org/packages/NHystrix

## Documentation

### VersionTelemetryInitializer

`VersionTelemetryInitializer` sets the `TelemetryContext.Component.Version` property to your application's version. 
The default constructor will use the version of the entry assembly (your main executable).

``` cs
protected void Application_Start()
{
    // ...
    TelemetryConfiguration.Active.TelemetryInitializers
    .Add(new VersionTelemetryInitializer());
}
``` 

You can explicitly specify the version by passing it into the constructor:

``` cs
protected void Application_Start()
{
    // ...
    TelemetryConfiguration.Active.TelemetryInitializers
    .Add(new VersionTelemetryInitializer("1.0.0"));
}
``` 


### Http4xxSuccessTelemetryInitializer

`Http4xxSuccessTelemetryInitializer` sets the success property to `true` if the response code is in the 400 range. 
By default, the Application Insights SDK sets this property to `false` for 4xx codes. If you're using 4xx codes for
valid business responses, such as a 404 when a given entity isn't found, then this can create noise.

``` cs
protected void Application_Start()
{
    // ...
    TelemetryConfiguration.Active.TelemetryInitializers
    .Add(new Http4xxSuccessTelemetryInitializer());
}
``` 

## Bugs and Feedback

For bugs, questions and discussions please use the [GitHub Issues](https://github.com/milestonetg/milestonetg-application-insights/issues).
