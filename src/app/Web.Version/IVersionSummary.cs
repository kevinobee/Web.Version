using System.Web;

namespace Web.Version
{
    internal interface IVersionSummary
    {
        void Render(HttpResponse response, string buildVersion);
    }
}