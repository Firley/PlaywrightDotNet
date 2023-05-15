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
    public abstract class ApiRequest : PlaywrightTest
    {
        protected IAPIRequestContext Request = null!;
        public TestsSettings Settings { get; }

        protected abstract string Route { get; }
        public ApiRequest(TestsSettings settings)
        {
            this.Settings = settings;
        }
        public async Task CreateApiRequestAsync()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Accept", "application/json");
            Request = await Playwright.APIRequest.NewContextAsync(new()
            {
                BaseURL = Settings.ApiUrl,
                ExtraHTTPHeaders = headers,
            });
        }
    }
}
