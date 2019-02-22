using System.IO;
using Microsoft.Extensions.Configuration;
using RoadStatus.Code.Contracts;

namespace RoadStatus.Code.Concretes
{
    public class ConfigReader : IConfigReader
    {
        private readonly IConfigurationRoot configuration;
        public ConfigReader()
        {
            this.configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public string GetApiPath()
        {
            return this.configuration["ApiPath"];
        }

        public string GetAppId()
        {
            return this.configuration["AppId"];
        }

        public string GetAppKey()
        {
            return this.configuration["AppKey"];
        }
    }
}