using System.Collections.Generic;
using RoadStatus.Code.Dtos;

namespace RoadStatus.Code.Contracts
{
    public interface IRoadService
    {
        IEnumerable<RoadCorridor> GetRoadStatus(string road);
    }
}