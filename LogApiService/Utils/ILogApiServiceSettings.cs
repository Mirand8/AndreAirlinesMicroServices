namespace LogApiService.Utils
{
    public interface ILogApiServiceSettings
    {
        string LogCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}