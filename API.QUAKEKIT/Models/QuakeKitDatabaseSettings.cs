namespace API.QUAKEKIT.Models
{
    public class QuakeKitDatabaseSettings : IQuakeKitDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string Secret { get; set; }
    }

    public interface IQuakeKitDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string Secret { get; set; }
    }
}
