namespace MelodeonApi.Models.Dtos
{
    public class ServiceStatusDto
    {
        public bool WebService { set; get; }
        public bool Api { set; get; }
        public bool Database { set; get; }
    }
}