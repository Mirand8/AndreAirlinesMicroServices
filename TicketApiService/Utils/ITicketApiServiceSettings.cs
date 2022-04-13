namespace TicketApiService.Utils
{
    public interface ITicketApiServiceSettings
    {
        string TicketCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
