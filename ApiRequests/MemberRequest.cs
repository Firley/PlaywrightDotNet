using Newtonsoft.Json.Linq;
using PlaywrightTests.cofiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTests.ApiRequests
{
    public class MemberRequest : ApiRequest
    {
        protected override string Route => "members";
        public MemberRequest(TestsSettings settings) : base(settings)
        {

        }

        public override async Task MakeGETBoardRequestAsync(string userId)
        {
            var issues = await Request.GetAsync($"{Route}/" + userId + "/boards" + $"? {Settings.ApiKey}" + "&" + Settings.Token);
        }


    }
}
