using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RP.Core31.AppData.Models;
using RP.Core31.Pages.HelperUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace RP.Core31.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<IndexModel> _logger;
        private readonly BusinessInfo _options;
        public string version;
        public string ThisEnvironment { get; set; }
        public string CurrentRunTimeVersion { get; set; }
        public string MyApplicationName { get; set; }
        public string SolutionName { get; set; }
        public string TargetFramework { get; set; }
        public string DotNetCoreVersion;
        public string BusinessName { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment env, IOptions<BusinessInfo> busOptions)
        {
            _logger = logger;
            _env = env;
            _options = busOptions.Value;
            DotNetCoreVersion = SystemHelpers.getCoreVersion();
        }

        public void OnGet()
        {
            SolutionName = DevFileUtilities.GetSolutionFileName();
            ThisEnvironment = _env.EnvironmentName;
            MyApplicationName = _env.ApplicationName;
            CurrentRunTimeVersion = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            version = "Version: " + @System.Environment.Version + " installed in: " + @System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            _logger.LogInformation("Completed Index.OnGet, {ThisEnvironment}!", ThisEnvironment);
            var asembli = Assembly.GetExecutingAssembly();
            var atrib = asembli.CustomAttributes.FirstOrDefault(a => a.AttributeType == typeof(TargetFrameworkAttribute));
            TargetFramework = atrib?.ConstructorArguments[0].Value.ToString();
            DotNetCoreVersion = SystemHelpers.getCoreVersion(TargetFramework);

            BusinessName = _options.BusinessName;
        }
    }
}
