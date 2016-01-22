﻿namespace Microsoft.ApplicationInsights.WindowsServer.Implementation
{
    using Microsoft.ApplicationInsights.Web.TestFramework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WebEventSourceTest
    {
        [TestMethod]
        public void MethodsAreImplementedConsistentlyWithTheirAttributes()
        {
            EventSourceTest.MethodsAreImplementedConsistentlyWithTheirAttributes(WindowsServerEventSource.Log);
        }
    }
}
