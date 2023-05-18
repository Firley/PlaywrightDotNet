using Microsoft.Playwright;
using PlaywrightTests.cofiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.ApiRequests
{
    public class BoardRequest : ApiRequest
    {
        protected override string Route => "boards";
        public BoardRequest(TestsSettings settings, IAPIRequest request) : base(settings, request)
        {

        }

        public async Task GetBoardRequestAsync(string BoardId)
        {
            var issues = await RequestContext.GetAsync($"/{Route}/" + BoardId + $"? {Settings.ApiKey}" + "&" + Settings.Token);
        }

        public async Task DeleteBoardRequestAsync(string BoardId)
        {
            var issues = await RequestContext.DeleteAsync($"/{Route}/" + BoardId + $"? {Settings.ApiKey}" + "&" + Settings.Token);
        }
    }
}
