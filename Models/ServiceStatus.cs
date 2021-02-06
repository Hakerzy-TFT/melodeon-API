namespace MelodeonApi.Models
{
    public class ServiceStatus
    {
        public short ServiceStatusCode { get; set; }
        public string DebugMessage { get; set; }

        //todo implement constructor to load above properties from config
    }
}