namespace RoadStatus.Code.Contracts
{
    public interface IConfigReader
    {
        string GetAppId();
        string GetAppKey();
        string GetApiPath();
    }
}