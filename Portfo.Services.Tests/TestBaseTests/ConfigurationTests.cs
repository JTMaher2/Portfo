﻿using Microsoft.Extensions.Configuration;

using Portfo.API.Common.Settings;


namespace Portfo.Services.Tests.TestBaseTests
{
    [TestClass]
    public class ConfigurationTests : TestBase
    {
        [TestMethod]
        public async Task ConfigurationRoot_OK()
        {
            Assert.IsNotNull(_configurationRoot);
        }

        [TestMethod]
        public async Task AppSettingsIConfiguration_OK()
        {
            Assert.IsNotNull(_configurationRoot);

            var appSettings = _configurationRoot.GetSection(nameof(AppSettings));
            Assert.IsNotNull(appSettings);
        }

        [TestMethod]
        public async Task AppSettings_OK()
        {
            Assert.IsNotNull(_configurationRoot);

            var iConfiguration = _configurationRoot.GetSection(nameof(AppSettings));
            Assert.IsNotNull(iConfiguration);

            var appSettings = iConfiguration.Get<AppSettings>();
            Assert.IsNotNull(appSettings);
        }
    }
}
