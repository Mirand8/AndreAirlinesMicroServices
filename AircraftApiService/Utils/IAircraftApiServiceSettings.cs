namespace AircraftApiService
{
    public interface IAircraftApiServiceSettings
    {
        string ConnectionString { get; set; }
        string AircraftCollectionName { get; set; }
        string DatabaseName { get; set; }
    }
}