namespace LogApiService.Utils
{
    public class LogApiServiceSettings : ILogApiServiceSettings
    {
        public string LogCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
