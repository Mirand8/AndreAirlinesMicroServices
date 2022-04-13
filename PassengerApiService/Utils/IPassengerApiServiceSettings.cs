namespace PassengerApiService.Utils
{
    public interface IPassengerApiServiceSettings
    {
        string PassengerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}