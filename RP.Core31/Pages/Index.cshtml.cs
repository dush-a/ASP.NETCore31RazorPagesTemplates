using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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
        public string DotNetCoreVersion { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            DotNetCoreVersion = SystemHelpers.getCoreVersion();
        }

        public void OnGet()
        {

        }
    }
}
