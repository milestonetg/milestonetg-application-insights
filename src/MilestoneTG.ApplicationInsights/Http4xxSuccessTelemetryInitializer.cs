using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using System;

namespace MilestoneTG.ApplicationInsights
{
    /// <summary>
    /// Marks HTTP 4xx as success instead of failure.
    /// </summary>
    /// <remarks>
    /// In ReSTful services, 4xx errors are part of normal business return codes. Tracking these as
    /// failures just creates noise in the dashoard and failure reports. This initializer will
    /// mark 4xx as "success". The request is still tracked, it's just considered a sucessful
    /// business transaction.
    /// </remarks>
    /// <seealso cref="Microsoft.ApplicationInsights.Extensibility.ITelemetryInitializer" />
    public class Http4xxSuccessTelemetryInitializer : ITelemetryInitializer
    {
        /// <summary>
        /// Initializes the specified telemetry.
        /// </summary>
        /// <param name="telemetry">The telemetry.</param>
        public void Initialize(ITelemetry telemetry)
        {
            var requestTelemetry = telemetry as RequestTelemetry;

            if (Int32.TryParse(requestTelemetry?.ResponseCode, out int code) && code >= 400 && code < 500)
            {
                // If we set the Success property, the SDK won't change it:
                requestTelemetry.Success = true;

                // Allow us to filter these requests in the portal:
                requestTelemetry.Context.Properties["Overridden4xx"] = "true";
            }
            // else leave the SDK to set the Success property  
        }
    }
}
