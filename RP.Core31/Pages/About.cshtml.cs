using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using RP.Core31.Pages.HelperUtilities;
using System.Runtime.Versioning;
using System.Reflection;
using System.Linq;

namespace RP.Core31.Pages
{
    public class AboutModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        public string OSDescription;
        public string ProcessArchitecture;
        public string VersionText;
        public string DotNetCoreVersion;
        public string NetFrameworkVer;
        public string CurrentRunTimeVersion { get; set; }
        public string ThisEnvironment { get; set; }
        public string MyApplicationName { get; set; }
        public string SolutionName { get; set; }
        public string? TargetFramework { get; set; }

        public AboutModel(IWebHostEnvironment env)
        {
            _env = env;
            SolutionName = DevFileUtilities.GetSolutionFileName();
            ThisEnvironment = _env.EnvironmentName;
            MyApplicationName = _env.ApplicationName;

            var atrib = Assembly.GetExecutingAssembly().CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            TargetFramework = atrib?.ConstructorArguments[0].Value?.ToString();

            // DotNetCoreVersion = getVersion(TargetFramework!);
            DotNetCoreVersion = SystemHelpers.getCoreVersion(TargetFramework!);

            OSDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ProcessArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();

            VersionText = "Version: " + @System.Environment.Version + " installed in: " + @System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();

            //DotNetCoreVersion = "" + @System.Environment.Version;
            NetFrameworkVer = SystemHelpers.GetInstalledDotNetFrameworkVersion();
            CurrentRunTimeVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription; ;
        }

        public void OnGet()
        {
            InitialiseVars();
        }

      private void InitialiseVars()
        {
            SolutionName = DevFileUtilities.GetSolutionFileName();
            ThisEnvironment = _env.EnvironmentName;
            MyApplicationName = _env.ApplicationName;

            var atrib = Assembly.GetExecutingAssembly().CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            TargetFramework = atrib?.ConstructorArguments[0].Value?.ToString();

            // DotNetCoreVersion = getVersion(TargetFramework!);
            DotNetCoreVersion = SystemHelpers.getCoreVersion(TargetFramework!);

            OSDescription = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
            ProcessArchitecture = System.Runtime.InteropServices.RuntimeInformation.ProcessArchitecture.ToString();

            VersionText = "Version: " + @System.Environment.Version + " installed in: " + @System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();

            //DotNetCoreVersion = "" + @System.Environment.Version;
            NetFrameworkVer = SystemHelpers.GetInstalledDotNetFrameworkVersion();
            CurrentRunTimeVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription; 
        }
    }
}
