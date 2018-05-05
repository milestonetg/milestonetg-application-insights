using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Reflection;

namespace MilestoneTG.ApplicationInsights
{
    /// <summary>
    /// Adds the Application Version to all telemetry.
    /// </summary>
    /// <seealso cref="Microsoft.ApplicationInsights.Extensibility.ITelemetryInitializer" />
    public class VersionTelemetryInitializer : ITelemetryInitializer
    {
        string version;

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionTelemetryInitializer"/> class deriving the version from
        /// the entry assembly.
        /// </summary>
        public VersionTelemetryInitializer()
            : this(Assembly.GetEntryAssembly())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionTelemetryInitializer"/> class with the specified version.
        /// </summary>
        /// <param name="version">The version.</param>
        public VersionTelemetryInitializer(string version)
        {
            this.version = version;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionTelemetryInitializer"/> class deriving the version from
        /// the AssemblyVersion of the supplied System.Type.
        /// </summary>
        /// <param name="type">The type.</param>
        public VersionTelemetryInitializer(Type type) 
            : this(type.GetTypeInfo().Assembly.GetName().Version.ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VersionTelemetryInitializer"/> class deriving the version from
        /// the AssemblyVersion of the supplied Assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public VersionTelemetryInitializer(Assembly assembly)
            : this(assembly.GetName().Version.ToString())
        {
        }

        /// <summary>
        /// Initializes the specified telemetry.
        /// </summary>
        /// <param name="telemetry">The telemetry.</param>
        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.Component.Version = version;           
        }
    }
}
