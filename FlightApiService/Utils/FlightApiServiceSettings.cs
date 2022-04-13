namespace FlightApiService.Utils
{
    public class FlightApiServiceSettings : IFlightApiServiceSettings

    {
        public string FlightCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
