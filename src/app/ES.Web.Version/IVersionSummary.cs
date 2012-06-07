using System.Web;

namespace ES.Web.Version
{
    internal interface IVersionSummary
    {
        void Render(HttpResponse response, string buildVersion);
    }
}