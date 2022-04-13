namespace BasePriceApiService.Utils
{
    public interface IBasePriceApiServiceSettings
    {
        string BasePriceCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}