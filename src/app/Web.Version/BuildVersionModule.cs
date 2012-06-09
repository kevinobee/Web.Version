using System;
using System.Web;
using Web.Version.Configuration;

namespace Web.Version
{
    public class BuildVersionModule : IHttpModule
    {
        private HttpApplication _application;
        private IVersionSummary _renderer;

        private static string _buildVersion;
        private static readonly object BuildVersionLockObject = new object();

        private IVersionProvider _versionProvider;

        public IVersionProvider VersionProvider
        {
            get { return _versionProvider ?? new AssemblyVersionProvider(); }
            set { _versionProvider = value; }
        }

        public string BuildVersion
        {
            get
            {
                if (_buildVersion == null)
                {
                    if (! string.IsNullOrEmpty(WebVersionConfiguration.Settings.ReportVersion))
                    {
                        _buildVersion = WebVersionConfiguration.Settings.ReportVersion;
                    }
                    else
                    {
                        lock (BuildVersionLockObject)
                        {
                            _buildVersion = VersionProvider.Version;
                        }                        
                    }
                }
                return _buildVersion;
            }
            set { _buildVersion = value; }
        }

        public void Init(HttpApplication context)
        {
            _application = context;

            if (WebVersionConfiguration.Settings.Enabled)
            {
                context.EndRequest += OnEndRequest;
            }
        }

        private void OnEndRequest(object sender, EventArgs e)
        {
            if (IsPage())
            {
                _renderer = new VersionSummary();
                _renderer.Render(_application.Response, BuildVersion);
            }
        }

        private bool IsPage()
        {
            return _application.Context.Handler is System.Web.UI.Page;
        }

        public void Dispose()
        {
        }
    }
}
