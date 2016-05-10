﻿namespace Microsoft.ApplicationInsights.AspNetCore
{ 
    using System.Linq;
    using System.Reflection;

    internal class SdkVersionUtils
    {
        internal static string GetFrameworkType()
        {
            string framework;
#if NET451
           // F representing the full framework
           framework = "aspnet5f:";
#else
            // C representing the core framework
            framework = "aspnet5c:";
#endif
            return framework;
        }

        internal static string GetAssemblyVersion()
        {
            return typeof(SdkVersionUtils).GetTypeInfo().Assembly.GetCustomAttributes<AssemblyInformationalVersionAttribute>()
                      .First()
                      .InformationalVersion;
        }
    }
}
