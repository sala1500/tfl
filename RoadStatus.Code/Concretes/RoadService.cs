using System.Collections.Generic;
using RoadStatus.Code.Contracts;
using RoadStatus.Code.Dtos;

namespace RoadStatus.Code.Concretes
{
    public class RoadService : IRoadService
    {
        private readonly string appId;
        private readonly string appKey;
        private readonly string apiPath;
        private readonly IApiReader apiReader;

        public RoadService() : this(new ConfigReader(), new ApiReader())
        {
        }

        public RoadService(IConfigReader reader, IApiReader apiReader)
        {
            this.appId = reader.GetAppId();
            this.appKey = reader.GetAppKey();
            this.apiPath = reader.GetApiPath();
            this.apiReader = apiReader;
        }

        public IEnumerable<RoadCorridor> GetRoadStatus(string roadName)
        {
            try
            {
                var road = roadName == null ? "" : $"/{roadName}";
                var path = $"{apiPath}{road}?app_id={appId}&app_key={appKey}";
                return apiReader.Get<RoadCorridor>(path);
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException($"{roadName} is not a valid road");
            }
        }
    }
}