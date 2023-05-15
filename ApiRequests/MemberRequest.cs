using Newtonsoft.Json.Linq;
using PlaywrightTests.ApiRequests.Models;
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

        public async Task<GetBoardsResponse> MakeGetMemberBoardsRequestAsync(string userId)
        {
            var issues = await Request.GetAsync($"{Route}/" + userId + "/boards" + $"? {Settings.ApiKey}" + "&" + Settings.Token);
            return await issues.JsonAsync<GetBoardsResponse>();
        }


    }
}
