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

        public BoardRequest(TestsSettings settings, IAPIRequest request) : base(settings, request) { }

        public async Task<IAPIResponse> GetBoardRequestAsync(string BoardId)
        {
            await CreateApiRequestContextAsync();

            return await RequestContext.GetAsync($"{Route}/" + BoardId + $"?key={Settings.ApiKey}" + "&token=" + Settings.Token);
        }

        public async Task<IAPIResponse> DeleteBoardRequestAsync(string BoardId)
        {
            await CreateApiRequestContextAsync();

            return await RequestContext.DeleteAsync($"{Route}/" + BoardId + $"?key={Settings.ApiKey}" + "&token=" + Settings.Token);
        }
    }
}
