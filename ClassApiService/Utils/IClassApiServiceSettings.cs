namespace ClassApiService.Utils
{
    public interface IClassApiServiceSettings
    {
        string ClassCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
