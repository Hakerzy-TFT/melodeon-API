namespace MelodeonApi.Models
{
    public class ServiceStatus
    {
        public short Code { get; set; }
        public string Message { get; set; }

        //todo implement constructor to load above properties from config
    }
}