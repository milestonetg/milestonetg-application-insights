using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MilestoneTG.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class VersionTests
    {
        [TestMethod]
        public void Version_should_get_set()
        {
            RequestTelemetry telemetry = new RequestTelemetry();

            const string version = "1.2.3.4";

            ITelemetryInitializer telemetryInitializer = new VersionTelemetryInitializer(version);

            telemetryInitializer.Initialize(telemetry);

            Assert.AreEqual(version, telemetry.Context.Component.Version);
        }
    }
}
