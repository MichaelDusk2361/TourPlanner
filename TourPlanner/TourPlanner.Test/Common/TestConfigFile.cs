using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Common;

namespace TourPlanner.Test.Common
{
    public class TestConfigFile
    {
        [Test]
        public void TestAppSettings_ThrowsIfNotParsed()
        {
            ConfigFile.Unload();
            Assert.Throws<InvalidOperationException>(() => ConfigFile.AppSettings("Host"));
        }

    }
}
