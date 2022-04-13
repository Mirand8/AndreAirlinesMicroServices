namespace BasePriceApiService.Utils
{
    public class BasePriceApiServiceSettings : IBasePriceApiServiceSettings
    {
        public string BasePriceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
