using System.Reflection;
using System.Web;

namespace Web.Version
{
    public class AssemblyVersionProvider : IVersionProvider
    {
        public string Version
        {
            get
            {
                var assembly = GetApplicationAssembly();
                return assembly != null ? assembly.GetName().Version.ToString() : null;
            }
        }

        private static Assembly GetApplicationAssembly()
        {
            // Try the EntryAssembly, this doesn't work for ASP.NET classic pipeline (untested on integrated)
            var ass = Assembly.GetEntryAssembly();

            // Look for web application assembly
            var ctx = HttpContext.Current;
            if (ctx != null)
            {
                ass = GetWebApplicationAssembly(ctx);
            }

            // Fallback to executing assembly
            return ass ?? (Assembly.GetExecutingAssembly());
        }

        private static Assembly GetWebApplicationAssembly(HttpContext context)
        {
            if ((context == null) || (context.CurrentHandler == null)) return null;

            const string aspNetNamespace = "ASP";

            var type = context.CurrentHandler.GetType();

            while (type != null && type != typeof(object) && type.Namespace == aspNetNamespace)
                type = type.BaseType;

            return type != null ? type.Assembly : null;
        }
    }
}