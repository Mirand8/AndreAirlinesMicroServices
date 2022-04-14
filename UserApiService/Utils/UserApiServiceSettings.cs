namespace UserApiService.Utils
{
    public class UserApiServiceSettings : IUserApiServiceSettings
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
