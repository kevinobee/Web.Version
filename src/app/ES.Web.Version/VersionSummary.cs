using System.Text;
using System.Web;

namespace ES.Web.Version
{
    internal class VersionSummary : IVersionSummary
    {
        private const string DivStyle = "style='font-family: tahoma; font-size: 11px; background-color: #829986; padding: 5px; position: absolute; top:0; left: 0px; filter:alpha(opacity=50); -moz-opacity:0.5; -khtml-opacity: 0.5; opacity: 0.5;'";

        public void Render(HttpResponse response, string buildVersion)
        {
            if (string.IsNullOrWhiteSpace(buildVersion)) return;

            var builder = new StringBuilder();

            builder.AppendFormat("<div id='VersionReport' {0}", DivStyle);
            builder.Append(" onmouseover=\"this.style.opacity=.9;this.style.filter='alpha(opacity=90)';this.style.MozOpacity=.9;this.style.KhtmlOpacity=.9;\"");
            builder.Append(" onmouseout=\"this.style.opacity=.5;this.style.filter='alpha(opacity=50)';this.style.MozOpacity=.5;this.style.KhtmlOpacity=.5;\"");
            builder.Append(">");
            builder.AppendFormat("<strong>Build Version: {0}</strong> - <a href=\"javascript:;\" onclick=\"document.getElementById('VersionReport').parentNode.removeChild(document.getElementById('VersionReport'));\">hide</a>", buildVersion);
            builder.Append("</div>");
            response.Write(builder.ToString());
        }
    }
}