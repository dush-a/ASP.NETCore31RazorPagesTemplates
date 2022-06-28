using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RP.Core31.AppData.Models;
using RP.Core31.Pages.HelperUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RP.Core31.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly BusinessInfo _options;

        public string DotNetCoreVersion { get; set; }
        public string BusinessName { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IOptions<BusinessInfo> busOptions)
        {
            _logger = logger;
            _options = busOptions.Value;
            DotNetCoreVersion = SystemHelpers.getCoreVersion();
        }

        public void OnGet()
        {
            BusinessName = _options.BusinessName;
        }
    }
}
