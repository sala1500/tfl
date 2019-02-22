using System.Collections.Generic;
using RoadStatus.Code.Dtos;

namespace RoadStatus.Code.Contracts
{
    public interface IApiReader
    {
        IEnumerable<T> Get<T>(string apiPath);
    }
}