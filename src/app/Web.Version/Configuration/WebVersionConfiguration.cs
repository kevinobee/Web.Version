using System.Configuration;

namespace Web.Version.Configuration
{
    public class WebVersionConfiguration : ConfigurationSection
    {
        private static readonly WebVersionConfiguration ConfigurationSettings;

        private const string enabled = "enabled";
        private const string responseHeaderEnabled = "responseHeaderEnabled";
        private const string reportVersion = "reportVersion";
        private const string autoHideInSeconds = "autoHideInSeconds";
        private const string htmlDivEnabled = "htmlDivEnabled";   
        

        static WebVersionConfiguration()
        {
            ConfigurationSettings = ConfigurationManager.GetSection("web.version") as WebVersionConfiguration;
        }

        public static WebVersionConfiguration Settings
        {
            get
            {
                return ConfigurationSettings;
            }
        }  

        [ConfigurationProperty(enabled
                , DefaultValue = false
                , IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)this[enabled]; }
            set { this[enabled] = value; }
        }

        [ConfigurationProperty(responseHeaderEnabled
                , DefaultValue = false
                , IsRequired = false)]
        public bool SendResponseHeader
        {
            get { return (bool)this[responseHeaderEnabled]; }
            set { this[responseHeaderEnabled] = value; }
        }

        [ConfigurationProperty(reportVersion
                , DefaultValue = null
                , IsRequired = false)]
        public string ReportVersion
        {
            get { return (string)this[reportVersion]; }
            set { this[reportVersion] = value; }
        }

        [ConfigurationProperty(autoHideInSeconds
                , DefaultValue = 0
                , IsRequired = false)]
        [IntegerValidator(MinValue = 0, MaxValue = 60)]
        public int AutoHideInSeconds
        {
            get { return (int)this[autoHideInSeconds]; }
            set { this[autoHideInSeconds] = value; }
        }

        [ConfigurationProperty(htmlDivEnabled
        , DefaultValue = true
        , IsRequired = false)]
        public bool HtmlDivEnabled
        {
            get { return (bool)this[htmlDivEnabled]; }
            set { this[htmlDivEnabled] = value; }
        }
    }
}
