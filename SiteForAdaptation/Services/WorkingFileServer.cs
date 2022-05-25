using System.IO;

namespace SiteForAdaptation.Services
{
    public static class WorkingFileServer
    {
        public static string Deleted(string path)
        {
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                fileInf.Delete();

                return "файл удален";
            }
            return "файл не найден";
        }
    }
}
