using System.Text;
using System.Web;
using Web.Version.Configuration;

namespace Web.Version
{
    internal class VersionSummary : IVersionSummary
    {
        private const string DivStyle = "style='font-family: tahoma; font-size: 11px; background-color: #829986; padding: 5px; position: absolute; top:0; left: 0px; filter:alpha(opacity=50); -moz-opacity:0.5; -khtml-opacity: 0.5; opacity: 0.5;'";

        public void Render(HttpResponse response, string buildVersion)
        {
            if (string.IsNullOrEmpty(buildVersion)) return;

            SetHtmlDiv(response, buildVersion);

            SetResponseHeader(response, buildVersion);
        }

        private static void SetHtmlDiv(HttpResponse response, string buildVersion)
        {
            if (WebVersionConfiguration.Settings.HtmlDivEnabled)
            {
                var builder = new StringBuilder();

                builder.AppendFormat("<div id='VersionReport' {0}", DivStyle);
                builder.Append(
                    " onmouseover=\"this.style.opacity=.9;this.style.filter='alpha(opacity=90)';this.style.MozOpacity=.9;this.style.KhtmlOpacity=.9;\"");
                builder.Append(
                    " onmouseout=\"this.style.opacity=.5;this.style.filter='alpha(opacity=50)';this.style.MozOpacity=.5;this.style.KhtmlOpacity=.5;\"");
                builder.Append(">");
                builder.AppendFormat(
                    "<strong>Build Version: {0}</strong> - <a href=\"javascript:;\" onclick=\"document.getElementById('VersionReport').parentNode.removeChild(document.getElementById('VersionReport'));\">hide</a>",
                    buildVersion);
                builder.Append("</div>");

                SetAutoHideScript(builder);

                response.Write(builder.ToString());
            }
        }

        private static void SetAutoHideScript(StringBuilder builder)
        {
            if (WebVersionConfiguration.Settings.AutoHideInSeconds > 0)
            {
                var waitMs = WebVersionConfiguration.Settings.AutoHideInSeconds*1000;

                builder.Append(
                    @"
                    <script>
                            window.onload = function () {                  
                                setTimeout(function () {
                                    var elem = document.getElementById('VersionReport');
                                    elem.parentNode.removeChild(elem); 
                                }, " + waitMs + @");
                        };
                    </script>");
            }
        }

        private static void SetResponseHeader(HttpResponse response, string buildVersion)
        {
            if (WebVersionConfiguration.Settings.SendResponseHeader)
            {
                response.AppendHeader("X-Web-Version", buildVersion);
            }
        }
    }
}