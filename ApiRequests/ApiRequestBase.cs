using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollector.InProcDataCollector;
using PlaywrightTests.cofiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.ApiRequests
{
    public abstract class ApiRequest
    {
        protected IAPIRequestContext RequestContext = null!;
        protected IAPIRequest request = null!;
        public TestsSettings Settings { get; }

        protected abstract string Route { get; }
        public ApiRequest(TestsSettings settings, IAPIRequest request)
        {
            this.Settings = settings;
            this.request = request;
        }
        public async Task CreateApiRequestContextAsync()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");
            RequestContext = await request.NewContextAsync(new()
            {
                BaseURL = Settings.ApiUrl,
                ExtraHTTPHeaders = headers,
            });
        }
    }
}
