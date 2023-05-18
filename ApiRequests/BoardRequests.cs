using Microsoft.Playwright;
using PlaywrightTests.cofiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.ApiRequests
{
    public class BoardRequests : ApiRequest
    {
        protected override string Route => "boards";
        public BoardRequests(TestsSettings settings, IAPIRequest request) : base(settings, request)
        {

        }

        public async Task MakeGETBoardRequestAsync(string BoardId)
        {
            var issues = await RequestContext.GetAsync($"/{Route}/" + BoardId + $"? {Settings.ApiKey}" + "&" + Settings.Token);
        }
    }
}
