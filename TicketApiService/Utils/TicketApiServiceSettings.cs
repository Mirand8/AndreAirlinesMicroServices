namespace TicketApiService.Utils
{
    public class TicketApiServiceSettings : ITicketApiServiceSettings
    {
        public string TicketCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
