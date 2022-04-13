namespace PassengerApiService.Utils
{
    public class PassengerApiServiceSettings : IPassengerApiServiceSettings
    {
        public string PassengerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
