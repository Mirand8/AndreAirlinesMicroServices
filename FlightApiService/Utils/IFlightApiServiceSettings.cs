namespace FlightApiService.Utils
{
    public interface IFlightApiServiceSettings
    {
        string FlightCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}