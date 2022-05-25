namespace SiteForAdaptation.Services
{
    public static class BaseService
    {
        public static string GetHostName()
        {
            return "localhost:5001";
            //return System.Net.Dns.GetHostName();
        }
    }
}
