using NUnit.Framework;
using RoadStatus.Code.Concretes;

namespace RoadStatus.Tests
{
    public class ConfigReaderTests
    {
        private ConfigReader reader;

        [SetUp]
        public void Setup()
        {
            reader = new ConfigReader();
        }

        [Test]
        public void GetAppId_ValidAppsettings_AppIdReturned()
        {
            var expected = "4a0deb66";
            var actual = reader.GetAppId();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetAppKey_ValidAppsettings_AppKeyReturned()
        {
            var expected = "69d009fdac45c18b1f4cf302eabc3e62";
            var actual = reader.GetAppKey();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetApiPath_ValidAppsettings_ApiPathReturned()
        {
            var expected = "https://api.tfl.gov.uk/road";
            var actual = reader.GetApiPath();
            Assert.AreEqual(expected, actual);
        }
    }
}