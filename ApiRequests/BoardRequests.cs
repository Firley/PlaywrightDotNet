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
        public BoardRequests(TestsSettings settings) : base(settings)
        {

        }

        public async Task MakeGETBoardRequestAsync(string BoardId)
        {
            var issues = await Request.GetAsync($"/{Route}/" + BoardId + $"? {Settings.ApiKey}" + "&" + Settings.Token);
        }
    }
}
