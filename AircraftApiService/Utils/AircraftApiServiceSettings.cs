namespace AircraftApiService
{
    public class AircraftApiServiceSettings : IAircraftApiServiceSettings
    {
        public string AircraftCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
