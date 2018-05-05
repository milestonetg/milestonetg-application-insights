using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MilestoneTG.ApplicationInsights;

namespace UnitTests
{
    [TestClass]
    public class Http4xxTests
    {
        [DataTestMethod]
        [DataRow(400)]
        [DataRow(401)]
        [DataRow(403)]
        [DataRow(404)]
        [DataRow(405)]
        [DataRow(409)]
        [DataRow(426)]
        public void Response_codes_between_400_499_should_be_success(int code)
        {
            RequestTelemetry telemetry = new RequestTelemetry() { ResponseCode = code.ToString() };

            ITelemetryInitializer telemetryInitializer = new Http4xxSuccessTelemetryInitializer();

            telemetryInitializer.Initialize(telemetry);

            Assert.AreEqual(true, telemetry.Success);
            Assert.AreEqual("true", telemetry.Context.Properties["Overridden4xx"]);
        }

        [TestMethod]
        public void Non_RequestTelemetry_should_not_set_success()
        {
            DependencyTelemetry telemetry = new DependencyTelemetry();

            ITelemetryInitializer telemetryInitializer = new Http4xxSuccessTelemetryInitializer();

            bool? previousValue = telemetry.Success;

            telemetryInitializer.Initialize(telemetry);

            Assert.AreEqual(previousValue, telemetry.Success);
            Assert.IsFalse(telemetry.Context.Properties.ContainsKey("Overridden4xx"));
        }
    }
}
