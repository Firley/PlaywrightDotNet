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
        public BoardRequest(TestsSettings settings) : base(settings)
        {

        }

        public sasync Task MakeGETBoardRequestAsync(string id)
        {
            var issues = await Request.GetAsync($"/{Route}/" + "id" + $"? {Settings.ApiKey}" + "&" + Settings.Token);
        }
    }
}
