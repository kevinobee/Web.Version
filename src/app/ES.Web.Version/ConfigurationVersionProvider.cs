using System.Configuration;

namespace ES.Web.Version
{
    public class ConfigurationVersionProvider : IVersionProvider
    {
        public string Version
        {
            get { return GetBuildVersion(); }
        }

        private string GetBuildVersion()
        {
            return ConfigurationManager.AppSettings["Web.Version.Type"];
        }
    }
}